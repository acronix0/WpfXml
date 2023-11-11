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
    /// Логика взаимодействия для EditShowForm.xaml
    /// </summary>
    public partial class EditShowForm : Window
    {
        public Show UpdatedShow { get; private set; }

        public EditShowForm(Show showToEdit)
        {
            InitializeComponent();
            UpdatedShow = showToEdit;
            ShowIdTextBox.Text = showToEdit.ShowId.ToString();
            NameTextBox.Text = showToEdit.Name;
            RatingTextBox.Text = showToEdit.Rating.ToString();
            CostPerMinuteTextBox.Text = showToEdit.CostPerMinute.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(RatingTextBox.Text, out double rating) &&
                decimal.TryParse(CostPerMinuteTextBox.Text, out decimal costPerMinute) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                UpdatedShow.Name = NameTextBox.Text;
                UpdatedShow.Rating = rating;
                UpdatedShow.CostPerMinute = costPerMinute;

                this.DialogResult = true; // Закрыть окно и вернуть положительный результат
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
