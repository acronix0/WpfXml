using helloapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AgentForm.xaml
    /// </summary>
    public partial class AgentForm : Window
    {
        private List<Agent> entyties;

        public AgentForm()
        {
            InitializeComponent();

            entyties = XmlDataManager.LoadData<Agent>("data/Agents.xml");

            dataGrid.ItemsSource = entyties;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addAgentForm = new AddAgentForm();
            var result = addAgentForm.ShowDialog();

            if (result == true)
            {
                
                var newAgent = addAgentForm.NewAgent; 

                if (newAgent != null)
                {
                    entyties.Add(newAgent);
                    XmlDataManager.SaveData("data/Advertisement.xml", entyties);
                    dataGrid.Items.Refresh(); 
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAd = dataGrid.SelectedItem as Agent;
            if (selectedAd != null)
            {
                var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное объявление?",
                                                       "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entyties.Remove(selectedAd);
                    dataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Advertisement.xml", entyties);
                    dataGrid.ItemsSource = entyties;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите объявление для удаления.", "Объявление не выбрано", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = dataGrid.SelectedItem as Agent;
            if (selected != null)
            {
                var editForm = new EditAgentForm(selected);
                if (editForm.ShowDialog() == true)
                {
                    int index = entyties.IndexOf(selected);
                    entyties[index] = editForm.UpdatedAgent;
                    dataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/Advertisement.xml", entyties);
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = entyties.Where(agent =>
                agent.Name.ToLower().Contains(searchText) ||
                agent.AgentId.ToString().Contains(searchText) ||
                agent.CommissionPercentage.ToString().Contains(searchText) ||
                agent.TotalSalesAmount.ToString().Contains(searchText)).ToList();
            dataGrid.ItemsSource = filteredList;
        }
    } 



}
