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
    /// Логика взаимодействия для ShowForm.xaml
    /// </summary>
    public partial class ShowForm : Window
    {
        private List<Show> entities;

        public ShowForm()
        {
            InitializeComponent();
            XmlDataManager.SaveData("data/Customers.xml", new List<Show>() { new Show() { Name="123",CostPerMinute=1,Rating=5,ShowId = 0} });

            entities = XmlDataManager.LoadData<Show>("data/Shows.xml");

            dataGrid.ItemsSource = entities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addShowForm = new AddShowForm();
            var result = addShowForm.ShowDialog();

            if (result == true)
            {
                var newShow = addShowForm.NewShow;

                if (newShow != null)
                {
                    entities.Add(newShow);
                    XmlDataManager.SaveData("data/Shows.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedShow = dataGrid.SelectedItem as Show;
            if (selectedShow != null)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное шоу?",
                                                       "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedShow);
                    dataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Shows.xml", entities);
                    dataGrid.ItemsSource = entities;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите шоу для удаления.", "Шоу не выбрано", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = dataGrid.SelectedItem as Show;
            if (selected != null)
            {
                var editForm = new EditShowForm(selected);
                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);
                    entities[index] = editForm.UpdatedShow;
                    dataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/Shows.xml", entities);
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = entities.Where(show =>
                show.Name.ToLower().Contains(searchText) ||
                show.ShowId.ToString().Contains(searchText) ||
                show.Rating.ToString().Contains(searchText) ||
                show.CostPerMinute.ToString().Contains(searchText)).ToList();
            dataGrid.ItemsSource = filteredList;
        }
    }

}
