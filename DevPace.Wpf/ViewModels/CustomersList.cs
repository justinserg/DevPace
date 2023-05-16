using DevPace.Wpf.Api;
using Domain.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevPace.Wpf.ViewModels
{
    public class CustomersList : ObservableCollection<CustomerVM>
    {
        public CustomersList()
        {

        }

        public async void LoadData(int page = 1)
        {
            using (WebApiClient client = new WebApiClient())
            {
                this.ClearItems();
                var result = new List<Customer>(await client.GetCustomersAsync());

                foreach (var item in result)
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

        }
    }
}
