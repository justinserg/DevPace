using DevPace.Wpf.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DevPace.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SEARCHNAME_KEY = "Name";
        private const string SEARCHEMAIL_KEY = "Email";
        private const string SEARCHPHONE_KEY = "Phone";
        private const string SEARCHCOMPANY_KEY = "Company";
        public CustomersList Customers = new CustomersList();

        private Dictionary<string, string> searchValues;

        public MainWindow()
        {
            InitializeComponent();
            customersGrid.CanUserAddRows = false;
            customersGrid.CanUserDeleteRows = false;
            PreparePage();
            
        }

        private async Task PreparePage()
        {
            await Customers.LoadData(1);
            customersGrid.ItemsSource = Customers;
            UpdatePage();
            searchValues = new Dictionary<string, string>
            {
                { SEARCHNAME_KEY, "" },
                { SEARCHEMAIL_KEY, "" },
                { SEARCHPHONE_KEY, "" },
                { SEARCHCOMPANY_KEY, "" }
            };
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                CustomerVM customer = (CustomerVM)button.DataContext;
                EditWindow window = new EditWindow(customer);
                window.ShowDialog();
            }

        }

        private void UpdatePage()
        {
            tbPage.Text = $"{Customers.Page} / {Customers.PagesCount}";
        }

        private async void TbSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSearchVal(SEARCHNAME_KEY, sender);

            await UpdateData();

        }

        private async void TbSearchEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSearchVal(SEARCHEMAIL_KEY, sender);

            await UpdateData();
        }

        private async void TbSearchPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSearchVal(SEARCHPHONE_KEY, sender);

            await UpdateData();
        }

        private async void TbSearchCompany_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSearchVal(SEARCHCOMPANY_KEY, sender);

            await UpdateData();
        }

        private void UpdateSearchVal(string name, object sender)
        {
            if (searchValues.Keys.Contains(name))
            {
                searchValues[name] = ((TextBox)sender).Text;
            }
            else
            {
                searchValues.Add(name, ((TextBox)sender).Text);
            }
        }

        private async Task UpdateData()
        {
            Customer searchObject = GetSearchObject();
            await Customers.LoadData(1, searchObject);
        }

        private Customer GetSearchObject()
        {
            var name = searchValues[SEARCHNAME_KEY] ?? string.Empty;
            var company = searchValues[SEARCHCOMPANY_KEY] ?? string.Empty;
            var phone = searchValues[SEARCHPHONE_KEY] ?? string.Empty;
            var email = searchValues[SEARCHEMAIL_KEY] ?? string.Empty;

            return new Customer
            {
                Name = name,
                CompanyName = company,
                Phone = phone,
                Email = email
            };
        }

        private async void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if(Customers.Page < Customers.PagesCount)
            {
                await Customers.LoadData(Customers.Page + 1, GetSearchObject());
                UpdatePage();
            }
        }

        private async void tbPrev_Click(object sender, RoutedEventArgs e)
        {
            if (Customers.Page > 1)
            {
                await Customers.LoadData(Customers.Page - 1, GetSearchObject());
                UpdatePage();
            }
        }
    }
}
