using DatingAgency.Dtos;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingAgency.ApiClients
{
    public class ClientApiClient
    {
        private readonly HttpClient httpClient;

        public ClientApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7139/");
        }

        public async Task<RegisterClientResponseDto> RegisterClientAsync(RegisterClientRequestDto request)
        {
            string json = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PostAsync("api/Client/register", content);

            string responseJson = await response.Content.ReadAsStringAsync();

            RegisterClientResponseDto result =
                JsonConvert.DeserializeObject<RegisterClientResponseDto>(responseJson);

            if (result == null)
            {
                return new RegisterClientResponseDto
                {
                    Success = false,
                    Message = "Сервер повернув порожню відповідь."
                };
            }

            return result;
        }
    }
}