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
        private string detail_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";
        private string all_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/"; 

        public MainWindow()
        {
            InitializeComponent();
            List<Verkeersbord> verkeersborden = LoadSigns();
            AllSigns.ItemsSource = verkeersborden;
        }

        private List<Verkeersbord> LoadSigns()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(all_URL);
                List<Verkeersbord> verkeersborden = JsonConvert.DeserializeObject<List<Verkeersbord>>(json);
                return verkeersborden;
            }
        }

        private void GetSignleSign(int id)
        {
            string complete_URL = detail_URL + id;
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(complete_URL);
                Verkeersbord verkeersbord = JsonConvert.DeserializeObject<Verkeersbord>(json);
            }
        }
    }
}
