using helloapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace helloapp.Customer_forms
{
    /// <summary>
    /// Логика взаимодействия для CustomerForm.xaml
    /// </summary>
    public partial class CustomerForm : Window
    {
        private List<Customer> entities;

        public CustomerForm()
        {
            InitializeComponent();
            entities = XmlDataManager.LoadData<Customer>("data/Customers.xml");

            dataGrid.ItemsSource = entities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addAgentForm = new AddCustomerForm();
            var result = addAgentForm.ShowDialog();

            if (result == true)
            {

                var newAgent = addAgentForm.NewCustomer;

                if (newAgent != null)
                {
                    entities.Add(newAgent);
                    XmlDataManager.SaveData("data/Customers.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAd = dataGrid.SelectedItem as Customer;
            if (selectedAd != null)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное объявление?",
                                                       "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedAd);
                    dataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Customers.xml", entities);
                    dataGrid.ItemsSource = entities;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите объявление для удаления.", "Объявление не выбрано", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = dataGrid.SelectedItem as Customer;
            if (selected != null)
            {
                var editForm = new EditCustomerForm(selected);
                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);
                    entities[index] = editForm.UpdatedCustomer;
                    dataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/Customers.xml", entities);
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = entities.Where(customer =>
                customer.CustomerId.ToString().Contains(searchText) ||
                customer.Name.ToLower().Contains(searchText) ||
                (customer.BankingDetails != null && customer.BankingDetails.ToLower().Contains(searchText)) ||
                (customer.Phone != null && customer.Phone.Contains(searchText)) ||
                (customer.ContactPerson != null && customer.ContactPerson.ToLower().Contains(searchText))
            ).ToList();

            dataGrid.ItemsSource = filteredList;

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
