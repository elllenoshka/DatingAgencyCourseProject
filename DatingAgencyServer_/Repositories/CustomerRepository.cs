using DatingAgencyServer.Dtos;
using Microsoft.Data.SqlClient;

namespace DatingAgencyServer.Repositories
{
    public class CustomerRepository
    {
        private readonly string connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public List<Dictionary<string, object?>> GetAllPartners()
        {
            string query = @"
                SELECT 
                    cp.ClientProfileId,
                    u.FullName AS [ПІБ],
                    cp.Gender AS [Стать],
                    DATEDIFF(YEAR, cp.BirthDate, GETDATE()) AS [Вік],
                    cp.City AS [Місто],
                    cp.Height AS [Зріст],
                    cp.Education AS [Освіта],
                    cp.Occupation AS [Професія],
                    cp.Interests AS [Інтереси],
                    cp.AboutMe AS [Про себе]
                FROM ClientProfiles cp
                INNER JOIN Users u ON cp.UserId = u.UserId
                WHERE u.IsActive = 1
                ORDER BY cp.ClientProfileId;";

            return ExecuteTable(query, null);
        }

        public List<Dictionary<string, object?>> FilterPartners(PartnerFilterRequestDto filter)
        {
            string query = @"
                SELECT 
                    cp.ClientProfileId,
                    u.FullName AS [ПІБ],
                    cp.Gender AS [Стать],
                    DATEDIFF(YEAR, cp.BirthDate, GETDATE()) AS [Вік],
                    cp.City AS [Місто],
                    cp.Height AS [Зріст],
                    cp.Education AS [Освіта],
                    cp.Occupation AS [Професія],
                    cp.Interests AS [Інтереси],
                    cp.AboutMe AS [Про себе]
                FROM ClientProfiles cp
                INNER JOIN Users u ON cp.UserId = u.UserId
                WHERE u.IsActive = 1
                  AND (@AgeMin = 0 OR DATEDIFF(YEAR, cp.BirthDate, GETDATE()) >= @AgeMin)
                  AND (@AgeMax = 0 OR DATEDIFF(YEAR, cp.BirthDate, GETDATE()) <= @AgeMax)
                  AND (@HeightMin = 0 OR cp.Height >= @HeightMin)
                  AND (@HeightMax = 0 OR cp.Height <= @HeightMax)
                  AND (@City = N'Усі міста' OR cp.City = @City)
                  AND (@Education = N'Будь-яка' OR cp.Education = @Education)
                ORDER BY cp.ClientProfileId;";

            return ExecuteTable(query, filter);
        }

        private List<Dictionary<string, object?>> ExecuteTable(
            string query,
            PartnerFilterRequestDto? filter)
        {
            List<Dictionary<string, object?>> rows = new List<Dictionary<string, object?>>();

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            if (filter != null)
            {
                command.Parameters.AddWithValue("@AgeMin", filter.AgeMin);
                command.Parameters.AddWithValue("@AgeMax", filter.AgeMax);
                command.Parameters.AddWithValue("@HeightMin", filter.HeightMin);
                command.Parameters.AddWithValue("@HeightMax", filter.HeightMax);
                command.Parameters.AddWithValue("@City", filter.City);
                command.Parameters.AddWithValue("@Education", filter.Education);
            }

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dictionary<string, object?> row = new Dictionary<string, object?>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                    row[reader.GetName(i)] = value;
                }

                rows.Add(row);
            }

            return rows;
        }
    }
}