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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
          
        private string path = @"C:\data\data.json";
        private bool isContains = false;
        public Edit()
        {
            InitializeComponent();
        }
        public void Check(ObservableCollection<User> users,String id)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    isContains = true;
                }
            }
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
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
                    Check(users, id.Text);
                    if (isContains == true&&(!String.IsNullOrWhiteSpace(name.Text)||!String.IsNullOrWhiteSpace(pos.Text)))
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].Id == id.Text)
                            {
                                users[i].FullName = name.Text;
                                users[i].Position = pos.Text;
                            }
                        }
                        string json2 = JsonConvert.SerializeObject(users);
                        using (StreamWriter stream = File.CreateText(path))
                        {
                            stream.Write(json2);
                        }
                        MessageBox.Show("Исправлен");
                    }
                    else
                    {
                        MessageBox.Show("введите id и хотя бы один элемент");
                    }


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
