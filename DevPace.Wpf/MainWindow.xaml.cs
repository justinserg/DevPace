using DevPace.Wpf.ViewModels;
using Domain.Entities;
using System.Windows;
using System.Windows.Controls;

namespace DevPace.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CustomersList Customers = new CustomersList();

        public MainWindow()
        {
            InitializeComponent();
            Customers.LoadData(1);
            customersGrid.ItemsSource = Customers;
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
    }
}
