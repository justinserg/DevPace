using DevPace.Wpf.Api;
using DevPace.Wpf.ViewModels;
using Domain.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DevPace.Wpf
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private CustomerVM _customer;

        public EditWindow(CustomerVM customer)
        {
            InitializeComponent();
            _customer = customer;
            grid.DataContext = _customer;
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (WebApiClient client = new WebApiClient())
            {
                var targetCustomer = new Customer
                {
                    CompanyName = _customer.CompanyName,
                    Email = _customer.Email,
                    Name = _customer.Name,
                    Phone = _customer.Phone
                };

                await client.UpdateCustomer(targetCustomer);
                Close();
                //}

            }
        }

    }
}
