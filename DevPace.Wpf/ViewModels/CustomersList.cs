using DevPace.Wpf.Api;
using Domain.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DevPace.Wpf.ViewModels
{
    public class CustomersList : ObservableCollection<CustomerVM>
    {
        public CustomersList()
        {

        }

        public int Page { get; set; }
        public int PagesCount { get; set; }

        public async Task LoadData(int page = 1, Customer customer = null)
        {
            if (customer == null)
            {
                customer = new Customer();
            }
            using WebApiClient client = new WebApiClient();
            ClearItems();
            var result = await client.GetCustomersAsync(page, customer);

            Page = result.Number;
            PagesCount = result.Count;

            if (result.Customers == null)
                return;

            foreach (var item in result.Customers)
            {
                this.Add(new CustomerVM
                {
                    Name = item.Name,
                    Phone = item.Phone,
                    CompanyName = item.CompanyName,
                    Email = item.Email
                });
            }

        }

        public Task Search(Customer searchObject)
        {
            using WebApiClient client = new WebApiClient();
            ClearItems();

            return null;
        }
    }
}
