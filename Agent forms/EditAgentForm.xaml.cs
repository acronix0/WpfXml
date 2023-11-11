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
    /// Логика взаимодействия для EditAgentForm.xaml
    /// </summary>
    public partial class EditAgentForm : Window
    {
        public Agent UpdatedAgent { get; private set; }
        public EditAgentForm(Agent agentToEdit)
        {
            InitializeComponent();
            UpdatedAgent = agentToEdit;
            AgentIdTextBox.Text = agentToEdit.AgentId.ToString();
            NameTextBox.Text = agentToEdit.Name;
            CommissionPercentageTextBox.Text = agentToEdit.CommissionPercentage.ToString();
            TotalSalesAmountTextBox.Text = agentToEdit.TotalSalesAmount.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация и сохранение изменений
            if (decimal.TryParse(CommissionPercentageTextBox.Text, out decimal commissionPercentage) &&
                decimal.TryParse(TotalSalesAmountTextBox.Text, out decimal totalSalesAmount) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                // Обновление данных агента
                UpdatedAgent.Name = NameTextBox.Text;
                UpdatedAgent.CommissionPercentage = commissionPercentage;
                UpdatedAgent.TotalSalesAmount = totalSalesAmount;

                this.DialogResult = true; // Закрыть окно и вернуть положительный результат
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
