using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TRAFFIC_APP
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {

        private string base_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";

        public DetailWindow(int id)
        {
            InitializeComponent();
            DetailGrid.DataContext = GetSignleSign(id);
        }

        private Verkeersbord GetSignleSign(int id)
        {
            string complete_URL = base_URL + id;
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(complete_URL);
                Verkeersbord verkeersbord = JsonConvert.DeserializeObject<Verkeersbord>(json);
                return verkeersbord;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
