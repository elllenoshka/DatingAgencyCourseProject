using DatingAgencyServer.Dtos;
using Microsoft.Data.SqlClient;

namespace DatingAgencyServer.Repositories
{
    public class MeetingRepository
    {
        private readonly string connectionString;

        public MeetingRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public List<Dictionary<string, object?>> GetSelectedMatch(int matchId)
        {
            string query = @"
                SELECT
                    m.MatchId,
                    u1.FullName AS [Перший клієнт],
                    u2.FullName AS [Другий клієнт],
                    m.CompatibilityScore AS [Сумісність],
                    m.Status AS [Статус]
                FROM Matches m
                INNER JOIN ClientProfiles cp1 ON m.FirstClientId = cp1.ClientProfileId
                INNER JOIN Users u1 ON cp1.UserId = u1.UserId
                INNER JOIN ClientProfiles cp2 ON m.SecondClientId = cp2.ClientProfileId
                INNER JOIN Users u2 ON cp2.UserId = u2.UserId
                WHERE m.MatchId = @MatchId;";

            return ExecuteTable(query, matchId);
        }

        public List<Dictionary<string, object?>> GetMeetingsForMatch(int matchId)
        {
            string query = @"
                SELECT
                    mt.MeetingId,
                    u.FullName AS [Працівник],
                    mt.MeetingDate AS [Дата зустрічі],
                    mt.Format AS [Формат],
                    mt.Location AS [Місце],
                    mt.Result AS [Статус],
                    mt.Notes AS [Примітки]
                FROM Meetings mt
                LEFT JOIN Users u ON mt.EmployeeId = u.UserId
                WHERE mt.MatchId = @MatchId
                ORDER BY mt.MeetingDate;";

            return ExecuteTable(query, matchId);
        }

        public void CreateMeeting(CreateMeetingRequestDto request)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string insertMeetingQuery = @"
                    INSERT INTO Meetings
                    (MatchId, EmployeeId, MeetingDate, Format, Location, Result, Notes)
                    VALUES
                    (@MatchId, @EmployeeId, @MeetingDate, @Format, @Location, @Result, @Notes);";

                SqlCommand insertCommand = new SqlCommand(insertMeetingQuery, connection, transaction);
                insertCommand.Parameters.AddWithValue("@MatchId", request.MatchId);
                insertCommand.Parameters.AddWithValue("@EmployeeId", (object?)request.EmployeeId ?? DBNull.Value);
                insertCommand.Parameters.AddWithValue("@MeetingDate", request.MeetingDate);
                insertCommand.Parameters.AddWithValue("@Format", request.Format);
                insertCommand.Parameters.AddWithValue("@Location", request.Location);
                insertCommand.Parameters.AddWithValue("@Result", request.Result);
                insertCommand.Parameters.AddWithValue("@Notes", request.Notes);

                insertCommand.ExecuteNonQuery();

                string updateMatchQuery = @"
                    UPDATE Matches
                    SET Status = N'Зустріч заплановано'
                    WHERE MatchId = @MatchId;";

                SqlCommand updateCommand = new SqlCommand(updateMatchQuery, connection, transaction);
                updateCommand.Parameters.AddWithValue("@MatchId", request.MatchId);

                updateCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private List<Dictionary<string, object?>> ExecuteTable(string query, int matchId)
        {
            List<Dictionary<string, object?>> rows = new List<Dictionary<string, object?>>();

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MatchId", matchId);

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