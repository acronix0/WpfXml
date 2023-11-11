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
    /// Логика взаимодействия для EditCustomerForm.xaml
    /// </summary>
    public partial class EditCustomerForm : Window
    {
        public Customer UpdatedCustomer { get; private set; }

        public EditCustomerForm(Customer customerToEdit)
        {
            InitializeComponent();
            UpdatedCustomer = customerToEdit;
            CustomerIdTextBox.Text = customerToEdit.CustomerId.ToString();
            NameTextBox.Text = customerToEdit.Name;
            BankingDetailsTextBox.Text = customerToEdit.BankingDetails;
            PhoneTextBox.Text = customerToEdit.Phone;
            ContactPersonTextBox.Text = customerToEdit.ContactPerson;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация введённых данных
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(BankingDetailsTextBox.Text) &&
                !string.IsNullOrWhiteSpace(PhoneTextBox.Text) &&
                !string.IsNullOrWhiteSpace(ContactPersonTextBox.Text))
            {
                // Обновление данных клиента
                UpdatedCustomer.Name = NameTextBox.Text;
                UpdatedCustomer.BankingDetails = BankingDetailsTextBox.Text;
                UpdatedCustomer.Phone = PhoneTextBox.Text;
                UpdatedCustomer.ContactPerson = ContactPersonTextBox.Text;

                this.DialogResult = true; // Закрыть окно и вернуть положительный результат
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
