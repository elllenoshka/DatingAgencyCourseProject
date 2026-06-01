using DatingAgencyServer.Dtos;
using Microsoft.Data.SqlClient;

namespace DatingAgencyServer.Repositories
{
    public class ClientRepository
    {
        private readonly string connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public bool EmailExists(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM Users
                    WHERE Email = @Email;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        public RegisterClientResponseDto RegisterClient(RegisterClientRequestDto request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    DateTime birthDate = DateTime.Today.AddYears(-request.Age);

                    string insertUserQuery = @"
                        INSERT INTO Users
                        (FullName, Email, PasswordHash, RoleId, Phone)
                        VALUES
                        (@FullName, @Email, @PasswordHash,
                         (SELECT RoleId FROM Roles WHERE RoleName = 'Client'),
                         NULL);

                        SELECT SCOPE_IDENTITY();";

                    SqlCommand userCommand = new SqlCommand(insertUserQuery, connection, transaction);
                    userCommand.Parameters.AddWithValue("@FullName", request.FullName);
                    userCommand.Parameters.AddWithValue("@Email", request.Email);
                    userCommand.Parameters.AddWithValue("@PasswordHash", request.Password);

                    int userId = Convert.ToInt32(userCommand.ExecuteScalar());

                    string insertProfileQuery = @"
                        INSERT INTO ClientProfiles
                        (UserId, Gender, BirthDate, City, Height, Education, Occupation, Interests, AboutMe)
                        VALUES
                        (@UserId, @Gender, @BirthDate, @City, @Height, @Education, @Occupation, @Interests, @AboutMe);

                        SELECT SCOPE_IDENTITY();";

                    SqlCommand profileCommand = new SqlCommand(insertProfileQuery, connection, transaction);
                    profileCommand.Parameters.AddWithValue("@UserId", userId);
                    profileCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    profileCommand.Parameters.AddWithValue("@BirthDate", birthDate);
                    profileCommand.Parameters.AddWithValue("@City", request.City);
                    profileCommand.Parameters.AddWithValue("@Height", request.Height);
                    profileCommand.Parameters.AddWithValue("@Education", request.Education);
                    profileCommand.Parameters.AddWithValue("@Occupation", request.Occupation);
                    profileCommand.Parameters.AddWithValue("@Interests", request.Interests);
                    profileCommand.Parameters.AddWithValue("@AboutMe", request.AboutMe);

                    int clientProfileId = Convert.ToInt32(profileCommand.ExecuteScalar());

                    string preferredGender = request.Gender == "Жінка" ? "Чоловік" : "Жінка";

                    string insertPreferenceQuery = @"
                        INSERT INTO PartnerPreferences
                        (ClientProfileId, PreferredGender, MinAge, MaxAge, PreferredCity, ImportantInterests)
                        VALUES
                        (@ClientProfileId, @PreferredGender, 18, 40, @PreferredCity, @ImportantInterests);";

                    SqlCommand preferenceCommand = new SqlCommand(insertPreferenceQuery, connection, transaction);
                    preferenceCommand.Parameters.AddWithValue("@ClientProfileId", clientProfileId);
                    preferenceCommand.Parameters.AddWithValue("@PreferredGender", preferredGender);
                    preferenceCommand.Parameters.AddWithValue("@PreferredCity", request.City);
                    preferenceCommand.Parameters.AddWithValue("@ImportantInterests", request.Interests);

                    preferenceCommand.ExecuteNonQuery();

                    transaction.Commit();

                    return new RegisterClientResponseDto
                    {
                        Success = true,
                        Message = "Реєстрація успішна.",
                        UserId = userId,
                        ClientProfileId = clientProfileId
                    };
                }
                catch
                {
                    transaction?.Rollback();
                    throw;
                }
            }
        }
    }
}