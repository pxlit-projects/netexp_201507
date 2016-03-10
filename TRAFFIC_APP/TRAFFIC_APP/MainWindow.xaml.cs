using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace TRAFFIC_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string base_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";
        public List<Verkeersbord> verkeersborden;

        public MainWindow()
        {
            InitializeComponent();
            if (verkeersborden == null)
            {
                verkeersborden = LoadSigns();
            }
            AllSigns.ItemsSource = verkeersborden;
        }

        private List<Verkeersbord> LoadSigns()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(base_URL);
                List<Verkeersbord> verkeersborden = JsonConvert.DeserializeObject<List<Verkeersbord>>(json);
                return verkeersborden;
            }
        }

        private void AllSigns_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = AllSigns.SelectedItem as Verkeersbord;
            DetailWindow detailWindow = new DetailWindow(item.id);
            detailWindow.Show();
            this.Close();
        }

        //handle double click add button
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        //handle double click filter
        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ( FilterBox.Text != null ) 
            {
                string searchString = FilterBox.Text;
                if (TypeCheck.IsChecked == true)
                {
                    List<Verkeersbord> filteredList = verkeersborden.FindAll(delegate(Verkeersbord obj) { return obj.type == searchString; });
                    AllSigns.ItemsSource = filteredList;
                }
                else
                {
                    List<Verkeersbord> filteredList = verkeersborden.FindAll(delegate(Verkeersbord obj) { return obj.vorm == searchString; });
                    AllSigns.ItemsSource = filteredList;
                }
            }
            else
            {
                AllSigns.ItemsSource = verkeersborden;
            }

        }

    }
}
