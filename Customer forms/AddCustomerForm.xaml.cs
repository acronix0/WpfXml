﻿using helloapp.Models;
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
    /// Логика взаимодействия для AddCustomerForm.xaml
    /// </summary>
    public partial class AddCustomerForm : Window
    {
        public Customer NewCustomer { get; private set; }

        public AddCustomerForm()
        {
            InitializeComponent();
            NewCustomer = new Customer();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int customerId;
            bool isCustomerIdValid = int.TryParse(CustomerIdTextBox.Text, out customerId);
            bool isNameValid = !string.IsNullOrWhiteSpace(NameTextBox.Text);
            bool isBankingDetailsValid = !string.IsNullOrWhiteSpace(BankingDetailsTextBox.Text);
            bool isPhoneValid = !string.IsNullOrWhiteSpace(PhoneTextBox.Text);
            bool isContactPersonValid = !string.IsNullOrWhiteSpace(ContactPersonTextBox.Text);

            if (isCustomerIdValid && isNameValid && isBankingDetailsValid && isPhoneValid && isContactPersonValid)
            {
                NewCustomer = new Customer
                {
                    CustomerId = customerId,
                    Name = NameTextBox.Text,
                    BankingDetails = BankingDetailsTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    ContactPerson = ContactPersonTextBox.Text
                };

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные и попробуйте снова.", "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
