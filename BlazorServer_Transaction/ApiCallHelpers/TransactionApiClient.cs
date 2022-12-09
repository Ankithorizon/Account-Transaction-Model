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
    public class TransactionApiClient
    {
        private readonly HttpClient _httpClient;

        public TransactionApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<BKProcessResponse> AddTransactionsToDB_BackgroundWorkerProcessAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/transaction/add_transactions_to_db");
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

        public async Task<List<Transaction>?> GetTransactionsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44339/api/transaction/get_transactions");
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();
                // this one doesn't work                
                // return JsonSerializer.Deserialize<List<Transaction>>(data);

                // use Newtonsoft.Json package
                return JsonConvert.DeserializeObject<List<Transaction>>(data);
            }
            catch (Exception ex)
            {
                // Log and notify user
            }
            return new List<Transaction>();
        }
    }
}
