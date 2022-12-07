using EFCore_Transaction.Models;
using Newtonsoft.Json;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServer_Transaction.ApiCallHelpers
{
    public class AccountApiClient
    {
        private readonly HttpClient _httpClient;

        public AccountApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<BKProcessResponse> AddAccountsToDB_BackgroundWorkerProcessAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/account/add_accounts_to_db");
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

        public async Task<List<Account>?> GetAccountsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/account/get_accounts");
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();
                // this one doesn't work                
                // return JsonSerializer.Deserialize<List<Account>>(data);

                // use Newtonsoft.Json package
                return JsonConvert.DeserializeObject<List<Account>>(data);
            }
            catch (Exception ex)
            {
                // Log and notify user
            }
            return new List<Account>();
        }
    }
}
