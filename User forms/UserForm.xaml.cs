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

namespace helloapp.User_forms
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        private List<User> entities;

        public UserForm()
        {
            InitializeComponent();
           
            entities = XmlDataManager.LoadData<User>("data/Users.xml");

            dataGrid.ItemsSource = entities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == true)
            {
                var newUser = addUserForm.NewUser;
                if (newUser != null)
                {
                    entities.Add(newUser);
                    XmlDataManager.SaveData("data/Users.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dataGrid.SelectedItem as User;
            if (selectedUser != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранного пользователя?",
                                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedUser);
                    XmlDataManager.SaveData("data/Users.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.", "Пользователь не выбран", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = dataGrid.SelectedItem as User;
            if (selected != null)
            {
                var editForm = new EditUserForm(selected);
                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);
                    entities[index] = editForm.UpdatedUser;
                    XmlDataManager.SaveData("data/Users.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = entities.Where(user =>
                user.Name.ToLower().Contains(searchText) ||
                user.UserId.ToString().Contains(searchText) ||
                user.Login.ToLower().Contains(searchText)).ToList(); // Поиск по паролю обычно не реализуется для безопасности
            dataGrid.ItemsSource = filteredList;
        }
    }

}
