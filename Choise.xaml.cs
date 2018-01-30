using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для Choise.xaml
    /// </summary>
    public partial class Choise : Page
    {
        private ObservableCollection<User> users;
        private string path = @"C:\data\data.json";
        public Choise()
        {
            InitializeComponent();

            if (File.Exists(path))
            {
                string json;
                using (StreamReader read = new StreamReader(path))
                {
                    json = read.ReadToEnd();
                }
                users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                data.ItemsSource = users;
                dataTime.DisplayDateEnd = DateTime.Now;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(dataTime.Text))
            {
                MessageBox.Show("выберите время!");
            }
            else
            {
                using (StreamWriter stream = File.CreateText(@"C:\data\"+ dataTime.Text + ".json"))
                {
                    string json2 = JsonConvert.SerializeObject(users);
                    stream.Write(json2);
                }
                MessageBox.Show("Отмечено");
            }
        }
        private void Button_Back(object sender, RoutedEventArgs e) =>
            this.NavigationService.Navigate(new Table());
    }
}
