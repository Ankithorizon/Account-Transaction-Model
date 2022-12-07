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
    public class PayeeApiClient
    {
        private readonly HttpClient _httpClient;

        public PayeeApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<BKProcessResponse> AddPayeesToDB_BackgroundWorkerProcessAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/payee/add_payees_to_db");
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

        public async Task<List<Payee>?> GetPayeesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/payee/get_payees");
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();
                // this one doesn't work                
                // return JsonSerializer.Deserialize<List<Payee>>(data);

                // use Newtonsoft.Json package
                return JsonConvert.DeserializeObject<List<Payee>>(data);
            }
            catch (Exception ex)
            {
                // Log and notify user
            }
            return new List<Payee>();
        }
    }
}
