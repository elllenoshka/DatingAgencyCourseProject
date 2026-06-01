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
    public class CustomerApiClient
    {
        private readonly HttpClient httpClient;

        public CustomerApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7139/");
        }

        public async Task<DataTable> GetAllPartnersAsync()
        {
            return await GetTableAsync("api/Customer/partners");
        }

        public async Task<DataTable> FilterPartnersAsync(PartnerFilterRequestDto filter)
        {
            string json = JsonConvert.SerializeObject(filter);

            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                await httpClient.PostAsync("api/Customer/partners/filter", content);

            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                ApiResponseDto error =
                    JsonConvert.DeserializeObject<ApiResponseDto>(responseJson);

                throw new Exception(error?.Message ?? "Помилка пошуку партнерів.");
            }

            return ConvertJsonToDataTable(responseJson);
        }

        private async Task<DataTable> GetTableAsync(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Сервер повернув помилку.");
            }

            return ConvertJsonToDataTable(json);
        }

        private DataTable ConvertJsonToDataTable(string json)
        {
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