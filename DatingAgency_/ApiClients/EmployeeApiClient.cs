using DatingAgency.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatingAgency.ApiClients
{
    public class EmployeeApiClient
    {
        private readonly HttpClient httpClient;

        public EmployeeApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7139/");
        }

        public async Task<DataTable> GetClientsAsync()
        {
            return await GetTableAsync("api/Employee/clients");
        }

        public async Task<DataTable> GetMatchesAsync()
        {
            return await GetTableAsync("api/Employee/matches");
        }

        public async Task<DataTable> GetMeetingsAsync()
        {
            return await GetTableAsync("api/Employee/meetings");
        }

        public async Task<CreateMatchResponseDto> CreateMatchAsync(int clientProfileId)
        {
            CreateMatchRequestDto request = new CreateMatchRequestDto
            {
                ClientProfileId = clientProfileId
            };

            string json = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                await httpClient.PostAsync("api/Employee/matches/create", content);

            string responseJson = await response.Content.ReadAsStringAsync();

            CreateMatchResponseDto result =
                JsonConvert.DeserializeObject<CreateMatchResponseDto>(responseJson);

            if (result == null)
            {
                return new CreateMatchResponseDto
                {
                    Success = false,
                    Message = "Сервер повернув порожню відповідь."
                };
            }

            return result;
        }

        private async Task<DataTable> GetTableAsync(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            List<Dictionary<string, object>> rows =
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            DataTable table = new DataTable();

            if (rows == null || rows.Count == 0)
            {
                return table;
            }

            foreach (string columnName in rows[0].Keys)
            {
                table.Columns.Add(columnName);
            }

            foreach (Dictionary<string, object> row in rows)
            {
                DataRow dataRow = table.NewRow();

                foreach (string columnName in row.Keys)
                {
                    object value = row[columnName];

                    if (value == null)
                    {
                        dataRow[columnName] = DBNull.Value;
                    }
                    else if (value is JValue jValue)
                    {
                        dataRow[columnName] = jValue.Value ?? DBNull.Value;
                    }
                    else
                    {
                        dataRow[columnName] = value;
                    }
                }

                table.Rows.Add(dataRow);
            }

            return table;
        }
    }
}