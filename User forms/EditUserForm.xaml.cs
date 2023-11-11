using helloapp.Models;
using System;using System.Collections.Generic;
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
    /// Логика взаимодействия для EditUserForm.xaml
    /// </summary>
    public partial class EditUserForm : Window
    {
        public User UpdatedUser { get; private set; }

        public EditUserForm(User userToEdit)
        {
            InitializeComponent();
            UpdatedUser = userToEdit;
            UserIdTextBox.Text = userToEdit.UserId.ToString();
            NameTextBox.Text = userToEdit.Name;
            LoginTextBox.Text = userToEdit.Login;
            PasswordTextBox.Text = userToEdit.Password; // Имейте в виду, что отображение пароля в текстовом поле может быть не безопасно
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Предполагаем, что валидация логина и имени происходит на уровне UI и не требует дополнительной логики
            // В вашем приложении стоит рассмотреть использование SecureString для паролей
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(LoginTextBox.Text) &&
                !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                UpdatedUser.Name = NameTextBox.Text;
                UpdatedUser.Login = LoginTextBox.Text;
                UpdatedUser.Password = PasswordTextBox.Text;

                this.DialogResult = true; // Закрыть окно и вернуть положительный результат
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
