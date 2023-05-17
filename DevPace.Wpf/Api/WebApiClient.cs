using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Collections.Specialized;
using System.Windows.Media;
using System.Collections;
using System.Windows.Controls;

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

        

        public async Task<Pagging> GetCustomersAsync(int page, Customer customer, CancellationToken cancellationToken = default)
        {
            try
            {
                var query = GetQueryFromCustomer(customer);
                var response = await client.GetFromJsonAsync<Pagging>($"{CUSTOMERS_RELATIVE_PATH}/{page}?{query}", cancellationToken);
                if (response != null)
                {
                    return response;
                }
            }
            catch(Exception ex)
            {

            }
            return new Pagging();
        }

        private string GetQueryFromCustomer(Customer customer)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrWhiteSpace(customer.CompanyName))
                queryString.Add(nameof(customer.CompanyName), customer.CompanyName);
            if (!string.IsNullOrWhiteSpace(customer.Name))
                queryString.Add(nameof(customer.Name), customer.Name);
            if (!string.IsNullOrWhiteSpace(customer.Email))
                queryString.Add(nameof(customer.Email), customer.Email);
            if (!string.IsNullOrWhiteSpace(customer.Phone))
                queryString.Add(nameof(customer.Phone), customer.Phone);

            return queryString.ToString();
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task UpdateCustomer(Customer customer, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await client.PutAsJsonAsync<Customer>($"{CUSTOMERS_RELATIVE_PATH}", customer, cancellationToken);
                
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await client.GetFromJsonAsync<Customer>($"{CUSTOMERS_RELATIVE_PATH}?name={name}", cancellationToken);
                if (response != null)
                {
                    return response;
                }
            }
            catch(HttpRequestException exception)
            {
                if (exception.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                
                throw;
            }
            
            return null;
        }
    }
}
