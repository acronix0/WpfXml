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
    /// Логика взаимодействия для AddUserForm.xaml
    /// </summary>
    public partial class AddUserForm : Window
    {
        public User NewUser { get; private set; }

        public AddUserForm()
        {
            InitializeComponent();
            NewUser = new User(); // Инициализация нового пользователя
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация полей ввода
            bool isUserIdValid = int.TryParse(UserIdTextBox.Text, out int userId);
            bool isNameValid = !string.IsNullOrWhiteSpace(NameTextBox.Text);
            bool isLoginValid = !string.IsNullOrWhiteSpace(LoginTextBox.Text);
            bool isPasswordValid = !string.IsNullOrWhiteSpace(PasswordBox.Password);

            if (isUserIdValid && isNameValid && isLoginValid && isPasswordValid)
            {
                NewUser = new User
                {
                    UserId = userId,
                    Name = NameTextBox.Text,
                    Login = LoginTextBox.Text,
                    Password = PasswordBox.Password // Примечание: в реальных системах пароль следует хешировать
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
