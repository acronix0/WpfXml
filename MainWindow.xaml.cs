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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace helloapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users = XmlDataManager.LoadData<User>(@"data/Users.xml");
            var user = Users.FirstOrDefault(u => u.Login == loginBox.Text && u.Password == passwordBox.Text);
            if (user != null)
            {
                MainMenue menue = new MainMenue(user.Name);
                menue.Show();
                Close();
            }
        }  
    }
}
