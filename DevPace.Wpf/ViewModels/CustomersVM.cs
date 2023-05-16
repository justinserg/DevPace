using DevPace.Wpf.Api;
using Domain.Entities;
using System.Collections.ObjectModel;

namespace DevPace.Wpf.ViewModels
{
    public class CustomersVM:ObservableCollection<Customer>
    {
        public CustomersVM()
        {
            
        }

        public async void LoadData(int page = 1)
        {
            using (WebApiClient client = new WebApiClient())
            {
                this.ClearItems();
                var result = new ObservableCollection<Customer>(await client.GetCustomersAsync());
                foreach(var item in result)
                {
                    this.Add(item);
                }
            }
               
        }
    }
}
