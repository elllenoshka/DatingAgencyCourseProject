using DatingAgencyServer.Dtos;
using Microsoft.Data.SqlClient;

namespace DatingAgencyServer.Repositories
{
    public class AuthRepository
    {
        private readonly string connectionString;

        public AuthRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public LoginResponseDto Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        u.UserId,
                        u.FullName,
                        r.RoleName
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleId = r.RoleId
                    WHERE u.Email = @Email
                      AND u.PasswordHash = @PasswordHash
                      AND u.IsActive = 1;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return new LoginResponseDto
                        {
                            Success = false,
                            Message = "Невірний email або пароль."
                        };
                    }

                    return new LoginResponseDto
                    {
                        Success = true,
                        Message = "Авторизація успішна.",
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FullName = reader["FullName"].ToString() ?? string.Empty,
                        RoleName = reader["RoleName"].ToString() ?? string.Empty
                    };
                }
            }
        }
    }
}