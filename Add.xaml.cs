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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        string path = @"C:\data\data.json";
        public Add()
        {
            InitializeComponent();
        }
        private void Button_Confirm(object sender,RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(id.Text) && String.IsNullOrWhiteSpace(name.Text) && String.IsNullOrWhiteSpace(pos.Text))
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
                    User user = new User();
                    user.Id = id.Text;
                    user.FullName = name.Text;
                    user.Position = pos.Text;
                    users.Add(user);
                    string json2 = JsonConvert.SerializeObject(users);
                    using (StreamWriter stream = File.CreateText(path))
                    {
                        stream.Write(json2);
                    }

                }
                else
                {
                    Directory.CreateDirectory(@"C:\data");
                    List<User> users = new List<User>();
                    User user = new User();
                    user.Id = id.Text;
                    user.FullName = name.Text;
                    user.Position = pos.Text;
                    users.Add(user);
                    string json = JsonConvert.SerializeObject(users);
                    using (StreamWriter stream = File.CreateText(path))
                    {
                        stream.Write(json);
                    }
                }
                MessageBox.Show("Добавлен");
            }
          
        }
        private void Button_Back(object sender, RoutedEventArgs e) =>
         this.NavigationService.Navigate(new Table());
        private void Button_Exit(object sender, RoutedEventArgs e) =>
         Application.Current.Shutdown();
    }
}
