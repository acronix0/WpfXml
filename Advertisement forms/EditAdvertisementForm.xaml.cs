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
    /// Логика взаимодействия для EditAdvertisementForm.xaml
    /// </summary>
    public partial class EditAdvertisementForm : Window
    {
        public Advertisement UpdatedAdvertisement { get; set; }

        public EditAdvertisementForm(Advertisement advertisementToEdit)
        {
            InitializeComponent();
            UpdatedAdvertisement = advertisementToEdit;
            AdIdTextBox.Text = advertisementToEdit.AdId.ToString();
            ShowIdTextBox.Text = advertisementToEdit.ShowId.ToString();
            CustomerIdTextBox.Text = advertisementToEdit.CustomerId.ToString();
            DateDatePicker.SelectedDate = advertisementToEdit.Date;
            DurationTextBox.Text = advertisementToEdit.DurationInMinutes.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация и сохранение изменений
            if (int.TryParse(AdIdTextBox.Text, out int adId) &&
                int.TryParse(ShowIdTextBox.Text, out int showId) &&
                int.TryParse(CustomerIdTextBox.Text, out int customerId) &&
                DateDatePicker.SelectedDate.HasValue &&
                int.TryParse(DurationTextBox.Text, out int duration))
            {
                // Обновление данных объявления
                UpdatedAdvertisement.AdId = adId;
                UpdatedAdvertisement.ShowId = showId;
                UpdatedAdvertisement.CustomerId = customerId;
                UpdatedAdvertisement.Date = DateDatePicker.SelectedDate.Value;
                UpdatedAdvertisement.DurationInMinutes = duration;

                this.DialogResult = true; // Закрыть окно и вернуть DialogResult.OK
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
