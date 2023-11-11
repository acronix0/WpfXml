using helloapp.Customer_forms;
using helloapp.Show_forms;
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
    /// Логика взаимодействия для MainMenue.xaml
    /// </summary>
    public partial class MainMenue : Window
    {
        public MainMenue(string userName)
        {
            InitializeComponent();
            UserLabel.Content = "Пользователь: " + userName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var advForm = new AdvertisementForm();
            advForm.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var agentForm = new AgentForm();
            agentForm.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var form = new CustomerForm();
            form.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var form = new ShowForm();
            form.ShowDialog();
        }
    }
}
