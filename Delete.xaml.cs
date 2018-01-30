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
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        private string path = @"C:\data\data.json";
        public Delete()
        {
            InitializeComponent();
        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Заполни");
            }
            else
            {

                if (File.Exists(path))
                {
                    ObservableCollection<User> users = new ObservableCollection<User>();
                    string json;
                    using (StreamReader read = new StreamReader(path))
                    {
                        json = read.ReadToEnd();
                    }
                    users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                    for(int i=0;i<users.Count;i++)
                    {
                        if(users[i].Id==id.Text)
                        {
                            users.Remove(users[i]);
                        }
                    }
                    string json2 = JsonConvert.SerializeObject(users);
                    using (StreamWriter stream = File.CreateText(path))
                    {
                        stream.Write(json2);
                    }
                    MessageBox.Show("удален");

                }
                else
                {
                    MessageBox.Show("лол, нету юзеров(");
                }
            }
        }
        private void Button_Back(object sender, RoutedEventArgs e) =>
         this.NavigationService.Navigate(new Table());
        private void Button_Exit(object sender, RoutedEventArgs e) =>
         Application.Current.Shutdown();
    }
}
