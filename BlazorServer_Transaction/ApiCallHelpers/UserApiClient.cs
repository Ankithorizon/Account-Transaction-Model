using Newtonsoft.Json;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServer_Transaction.ApiCallHelpers
{
    public class UserApiClient
    {
        private readonly HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
              

        public async Task<BKProcessResponse> AddUsersToDB_BackgroundWorkerProcessAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/user/add_users_to_db");
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<BKProcessResponse>(data);
                // return data;
            }
            catch (Exception ex)
            {
                // Log and notify user
            }

            return new BKProcessResponse();
        }
    }
}
