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

namespace helloapp.Show_forms
{
    /// <summary>
    /// Логика взаимодействия для AddShowForm.xaml
    /// </summary>
    public partial class AddShowForm : Window
    {
        public Show NewShow { get; private set; }
        
        public AddShowForm()
        {
            InitializeComponent();
            NewShow = new Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Поскольку ShowId обычно генерируется автоматически, здесь нет необходимости валидировать этот параметр
            if (double.TryParse(RatingTextBox.Text, out double rating) &&
                decimal.TryParse(CostPerMinuteTextBox.Text, out decimal costPerMinute) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NewShow = new Show
                {
                    // ShowId не включен, так как предполагается его автоматическая генерация
                    Name = NameTextBox.Text,
                    Rating = rating,
                    CostPerMinute = costPerMinute
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
