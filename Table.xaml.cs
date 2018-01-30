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
    /// Логика взаимодействия для Table.xaml
    /// </summary>

    public partial class Table : Page
    {
        private ObservableCollection<User> users;
        public Table()
        {
            string path = @"C:\data\data.json";
            InitializeComponent();
            if (File.Exists(path))
            {
                
                string json;
                using (StreamReader read = new StreamReader(path))
                {
                    json = read.ReadToEnd();
                }
                users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                data.ItemsSource=users;

            }



        }
        private void Button_Add(object sender,RoutedEventArgs e)=>
            this.NavigationService.Navigate(new Add());
        private void Button_Delete(object sender, RoutedEventArgs e)=>
           this.NavigationService.Navigate(new Delete());
        private void Button_Edit(object sender, RoutedEventArgs e)=>
           this.NavigationService.Navigate(new Edit());
        private void Button_Choise(object sender, RoutedEventArgs e) =>
       this.NavigationService.Navigate(new Choise());
        private void Button_Exit(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();
       
    }
         
}
