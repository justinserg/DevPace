using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevPace.Wpf.Api
{
    public class WebApiClient: IDisposable
    {
        HttpClient client = new HttpClient();
        private const string CUSTOMERS_RELATIVE_PATH = "api/customers";

        public WebApiClient() 
        {
            client.BaseAddress = new Uri("https://localhost:7232");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int page = 1, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await client.GetFromJsonAsync<IEnumerable<Customer>>($"{CUSTOMERS_RELATIVE_PATH}/{page}", cancellationToken);
                if (response != null)
                {
                    return response;
                }
            }
            catch(Exception ex)
            {

            }
            return new List<Customer>();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
