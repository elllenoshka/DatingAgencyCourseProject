using DatingAgency.Dtos;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingAgency.ApiClients
{
    public class AuthApiClient
    {
        private readonly HttpClient httpClient;

        public AuthApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7139/");
        }

        public async Task<LoginResponseDto> LoginAsync(string email, string password)
        {
            LoginRequestDto request = new LoginRequestDto
            {
                Email = email,
                Password = password
            };

            string json = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("api/Auth/login", content);

            string responseJson = await response.Content.ReadAsStringAsync();

            LoginResponseDto result = JsonConvert.DeserializeObject<LoginResponseDto>(responseJson);

            if (result == null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Сервер повернув порожню відповідь."
                };
            }

            return result;
        }
    }
}