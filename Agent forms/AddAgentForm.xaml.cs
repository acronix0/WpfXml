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

namespace helloapp
{
    /// <summary>
    /// Логика взаимодействия для AddAgentForm.xaml
    /// </summary>
    public partial class AddAgentForm : Window
    {
        public Agent NewAgent { get; private set; }

        public AddAgentForm()
        {
            InitializeComponent();
            NewAgent = new Agent(); 
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int agentId;
            decimal commissionPercentage;
            decimal totalSalesAmount;
            bool isAgentIdValid = int.TryParse(AgentIdTextBox.Text, out agentId);
            bool isCommissionPercentageValid = decimal.TryParse(CommissionPercentageTextBox.Text, out commissionPercentage);
            bool isTotalSalesAmountValid = decimal.TryParse(TotalSalesAmountTextBox.Text, out totalSalesAmount);
            bool isNameValid = !string.IsNullOrWhiteSpace(NameTextBox.Text);

            if (isAgentIdValid && isCommissionPercentageValid && isTotalSalesAmountValid && isNameValid)
            {
                NewAgent = new Agent
                {
                    AgentId = agentId,
                    Name = NameTextBox.Text,
                    CommissionPercentage = commissionPercentage,
                    TotalSalesAmount = totalSalesAmount
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
