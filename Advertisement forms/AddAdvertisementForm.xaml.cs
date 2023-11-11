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
    /// Логика взаимодействия для AddAdvertisementForm.xaml
    /// </summary>
    public partial class AddAdvertisementForm : Window
    {
        public Advertisement NewAdvertisement { get; private set; }

        public AddAdvertisementForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация введенных данных
            if (int.TryParse(AdIdTextBox.Text, out int adId) &&
                int.TryParse(ShowIdTextBox.Text, out int showId) &&
                int.TryParse(CustomerIdTextBox.Text, out int customerId) &&
                DateDatePicker.SelectedDate.HasValue &&
                int.TryParse(DurationTextBox.Text, out int duration))
            {
                // Создание нового объявления
                NewAdvertisement = new Advertisement
                {
                    AdId = adId,
                    ShowId = showId,
                    CustomerId = customerId,
                    Date = DateDatePicker.SelectedDate.Value,
                    DurationInMinutes = duration
                };

                this.DialogResult = true; // Закрыть окно и вернуть DialogResult.OK
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
