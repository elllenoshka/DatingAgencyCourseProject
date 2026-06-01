using DatingAgencyServer.Dtos;
using DatingAgencyServer.Repositories;

namespace DatingAgencyServer.Services
{
    public class AuthService
    {
        private readonly AuthRepository authRepository;

        public AuthService(AuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public LoginResponseDto Login(LoginRequestDto request)
        {
            if (request == null ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Email і пароль є обов’язковими."
                };
            }

            return authRepository.Login(request.Email.Trim(), request.Password.Trim());
        }
    }
}