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
    public partial class AdvertisementForm : Window
    {
        private List<Advertisement> advertisements;

        public AdvertisementForm()
        {
            InitializeComponent();

            advertisements = XmlDataManager.LoadData<Advertisement>("data/Advertisement.xml");

            AdvertisementsDataGrid.ItemsSource = advertisements;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new AddAdvertisementForm();
            if (addForm.ShowDialog() == true)
            {
                var newAd = addForm.NewAdvertisement;
                advertisements.Add(newAd);
                AdvertisementsDataGrid.Items.Refresh();
                XmlDataManager.SaveData("data/Advertisement.xml", advertisements);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAd = AdvertisementsDataGrid.SelectedItem as Advertisement;
            if (selectedAd != null)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное объявление?",
                                                       "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    advertisements.Remove(selectedAd);
                    AdvertisementsDataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Advertisement.xml", advertisements);
                    AdvertisementsDataGrid.ItemsSource = advertisements; 
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите объявление для удаления.", "Объявление не выбрано", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAd = AdvertisementsDataGrid.SelectedItem as Advertisement;
            if (selectedAd != null)
            {
                var editForm = new EditAdvertisementForm(selectedAd); 
                if (editForm.ShowDialog() == true)
                {
                    int index = advertisements.IndexOf(selectedAd);
                    advertisements[index] = editForm.UpdatedAdvertisement; 
                    AdvertisementsDataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/Advertisement.xml", advertisements);
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = advertisements.Where(advertisement =>
                advertisement.AdId.ToString().Contains(searchText) ||
                advertisement.ShowId.ToString().Contains(searchText) ||
                advertisement.CustomerId.ToString().Contains(searchText) ||
                advertisement.Date.ToString().ToLower().Contains(searchText) || // Предполагается использование ToString() и ToLower(), если дата включает текстовые данные, например, название месяца.
                advertisement.DurationInMinutes.ToString().Contains(searchText)
            ).ToList();

            AdvertisementsDataGrid.ItemsSource = filteredList;

        }
    }

}
