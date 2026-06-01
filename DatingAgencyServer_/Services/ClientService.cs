using DatingAgencyServer.Dtos;
using DatingAgencyServer.Repositories;

namespace DatingAgencyServer.Services
{
    public class ClientService
    {
        private readonly ClientRepository clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public RegisterClientResponseDto RegisterClient(RegisterClientRequestDto request)
        {
            if (request == null)
            {
                return new RegisterClientResponseDto
                {
                    Success = false,
                    Message = "Запит не може бути порожнім."
                };
            }

            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Gender) ||
                string.IsNullOrWhiteSpace(request.City) ||
                string.IsNullOrWhiteSpace(request.Education) ||
                string.IsNullOrWhiteSpace(request.Occupation) ||
                string.IsNullOrWhiteSpace(request.Interests) ||
                string.IsNullOrWhiteSpace(request.AboutMe) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return new RegisterClientResponseDto
                {
                    Success = false,
                    Message = "Будь ласка, заповніть всі поля."
                };
            }

            if (request.Age < 18)
            {
                return new RegisterClientResponseDto
                {
                    Success = false,
                    Message = "Реєстрація доступна тільки від 18 років."
                };
            }

            if (request.Height < 120 || request.Height > 230)
            {
                return new RegisterClientResponseDto
                {
                    Success = false,
                    Message = "Некоректно вказаний зріст."
                };
            }

            if (clientRepository.EmailExists(request.Email.Trim()))
            {
                return new RegisterClientResponseDto
                {
                    Success = false,
                    Message = "Користувач із таким email вже існує."
                };
            }

            request.FullName = request.FullName.Trim();
            request.Email = request.Email.Trim();
            request.Password = request.Password.Trim();
            request.City = request.City.Trim();
            request.Education = request.Education.Trim();
            request.Occupation = request.Occupation.Trim();
            request.Interests = request.Interests.Trim();
            request.AboutMe = request.AboutMe.Trim();

            return clientRepository.RegisterClient(request);
        }
    }
}