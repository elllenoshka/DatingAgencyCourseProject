using DatingAgencyServer.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatingAgencyServer.Repositories
{
    public class AdminRepository
    {
        private readonly string connectionString;

        public AdminRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public List<Dictionary<string, object?>> GetClients()
        {
            string query = @"
                SELECT 
                    cp.ClientProfileId,
                    u.FullName AS [ПІБ],
                    u.Email,
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

            return ExecuteTable(query);
        }

        public List<Dictionary<string, object?>> GetMatches()
        {
            string query = @"
                SELECT
                    m.MatchId,
                    u1.FullName AS [Перший клієнт],
                    u2.FullName AS [Другий клієнт],
                    m.CompatibilityScore AS [Сумісність],
                    m.Status AS [Статус],
                    m.CreatedAt AS [Дата створення]
                FROM Matches m
                INNER JOIN ClientProfiles cp1 ON m.FirstClientId = cp1.ClientProfileId
                INNER JOIN Users u1 ON cp1.UserId = u1.UserId
                INNER JOIN ClientProfiles cp2 ON m.SecondClientId = cp2.ClientProfileId
                INNER JOIN Users u2 ON cp2.UserId = u2.UserId
                ORDER BY m.MatchId;";

            return ExecuteTable(query);
        }

        public List<Dictionary<string, object?>> GetMeetings()
        {
            string query = @"
                SELECT
                    mt.MeetingId,
                    mt.MatchId,
                    u.FullName AS [Працівник],
                    mt.MeetingDate AS [Дата зустрічі],
                    mt.Format AS [Формат],
                    mt.Location AS [Місце],
                    mt.Result AS [Результат],
                    mt.Notes AS [Примітки]
                FROM Meetings mt
                LEFT JOIN Users u ON mt.EmployeeId = u.UserId
                ORDER BY mt.MeetingDate;";

            return ExecuteTable(query);
        }

        public List<Dictionary<string, object?>> GetArchive()
        {
            string query = @"
                SELECT
                    ma.ArchiveId,
                    ma.MatchId,
                    ma.ArchivedAt AS [Дата архівації],
                    ma.ArchiveReason AS [Причина]
                FROM MatchArchive ma
                ORDER BY ma.ArchiveId;";

            return ExecuteTable(query);
        }

        public List<Dictionary<string, object?>> GetEmployees()
        {
            string query = @"
                SELECT
                    u.UserId,
                    u.FullName AS [ПІБ],
                    u.Email,
                    u.Phone AS [Телефон],
                    u.Position AS [Посада],
                    u.IsActive AS [Активний],
                    u.CreatedAt AS [Дата створення]
                FROM Users u
                INNER JOIN Roles r ON u.RoleId = r.RoleId
                WHERE r.RoleName = 'Employee'
                ORDER BY u.UserId;";

            return ExecuteTable(query);
        }

        public PartnerDataDto? FindPartnerForClient(int selectedClientId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
                SELECT TOP 1
                    cp2.ClientProfileId,
                    u2.FullName,
                    cp2.City,
                    cp2.Education,
                    cp2.Interests,
                    cp2.BirthDate,
                    cp1.City AS SelectedCity,
                    cp1.Education AS SelectedEducation,
                    cp1.Interests AS SelectedInterests,
                    cp1.BirthDate AS SelectedBirthDate
                FROM ClientProfiles cp1
                INNER JOIN ClientProfiles cp2 ON cp1.ClientProfileId <> cp2.ClientProfileId
                INNER JOIN Users u2 ON cp2.UserId = u2.UserId
                WHERE cp1.ClientProfileId = @SelectedClientId
                  AND cp1.Gender <> cp2.Gender
                  AND u2.IsActive = 1
                  AND NOT EXISTS (
                      SELECT 1
                      FROM Matches m
                      WHERE 
                          (m.FirstClientId = cp1.ClientProfileId AND m.SecondClientId = cp2.ClientProfileId)
                          OR
                          (m.FirstClientId = cp2.ClientProfileId AND m.SecondClientId = cp1.ClientProfileId)
                  )
                ORDER BY 
                    CASE WHEN cp1.City = cp2.City THEN 1 ELSE 0 END DESC,
                    CASE WHEN cp1.Education = cp2.Education THEN 1 ELSE 0 END DESC;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SelectedClientId", selectedClientId);

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return new PartnerDataDto
            {
                PartnerClientProfileId = Convert.ToInt32(reader["ClientProfileId"]),
                PartnerName = reader["FullName"].ToString() ?? string.Empty,

                SelectedCity = reader["SelectedCity"].ToString() ?? string.Empty,
                SelectedEducation = reader["SelectedEducation"].ToString() ?? string.Empty,
                SelectedInterests = reader["SelectedInterests"].ToString() ?? string.Empty,
                SelectedBirthDate = Convert.ToDateTime(reader["SelectedBirthDate"]),

                PartnerCity = reader["City"].ToString() ?? string.Empty,
                PartnerEducation = reader["Education"].ToString() ?? string.Empty,
                PartnerInterests = reader["Interests"].ToString() ?? string.Empty,
                PartnerBirthDate = Convert.ToDateTime(reader["BirthDate"])
            };
        }

        public void InsertMatch(int firstClientId, int secondClientId, int compatibilityScore, string status)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
                INSERT INTO Matches 
                (FirstClientId, SecondClientId, CompatibilityScore, Status)
                VALUES 
                (@FirstClientId, @SecondClientId, @CompatibilityScore, @Status);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstClientId", firstClientId);
            command.Parameters.AddWithValue("@SecondClientId", secondClientId);
            command.Parameters.AddWithValue("@CompatibilityScore", compatibilityScore);
            command.Parameters.AddWithValue("@Status", status);

            command.ExecuteNonQuery();
        }

        public void DeleteMatch(int matchId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand deleteArchive = new SqlCommand(
                    "DELETE FROM MatchArchive WHERE MatchId = @MatchId",
                    connection,
                    transaction
                );
                deleteArchive.Parameters.AddWithValue("@MatchId", matchId);
                deleteArchive.ExecuteNonQuery();

                SqlCommand deleteMeetings = new SqlCommand(
                    "DELETE FROM Meetings WHERE MatchId = @MatchId",
                    connection,
                    transaction
                );
                deleteMeetings.Parameters.AddWithValue("@MatchId", matchId);
                deleteMeetings.ExecuteNonQuery();

                SqlCommand deleteMatch = new SqlCommand(
                    "DELETE FROM Matches WHERE MatchId = @MatchId",
                    connection,
                    transaction
                );
                deleteMatch.Parameters.AddWithValue("@MatchId", matchId);
                deleteMatch.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void ArchiveMatch(int matchId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
                IF NOT EXISTS (SELECT 1 FROM MatchArchive WHERE MatchId = @MatchId)
                BEGIN
                    INSERT INTO MatchArchive (MatchId, ArchiveReason)
                    VALUES (@MatchId, N'Пару перенесено до архіву адміністратором.');
                END

                UPDATE Matches
                SET Status = N'Архівовано'
                WHERE MatchId = @MatchId;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MatchId", matchId);

            command.ExecuteNonQuery();
        }

        public void SetEmployeeStatus(int userId, bool isActive)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
                UPDATE Users
                SET IsActive = @IsActive
                WHERE UserId = @UserId;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@UserId", userId);

            command.ExecuteNonQuery();
        }

        public bool EmployeeEmailExists(string email)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
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

        public void AddEmployee(AddEmployeeRequestDto request)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
                INSERT INTO Users
                (FullName, Email, PasswordHash, RoleId, Phone, Position, IsActive)
                VALUES
                (@FullName, @Email, @PasswordHash,
                 (SELECT RoleId FROM Roles WHERE RoleName = 'Employee'),
                 @Phone, @Position, 1);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", request.FullName);
            command.Parameters.AddWithValue("@Email", request.Email);
            command.Parameters.AddWithValue("@PasswordHash", request.Password);
            command.Parameters.AddWithValue("@Phone", request.Phone);
            command.Parameters.AddWithValue("@Position", request.Position);

            command.ExecuteNonQuery();
        }

        private List<Dictionary<string, object?>> ExecuteTable(string query)
        {
            List<Dictionary<string, object?>> rows = new List<Dictionary<string, object?>>();

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

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