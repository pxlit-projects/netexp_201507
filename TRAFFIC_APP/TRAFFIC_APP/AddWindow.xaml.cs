using Business_objects;
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
using Newtonsoft.Json;
using System.ComponentModel;

namespace TRAFFIC_APP
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private string post_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";

        Verkeersbord verkeersbord;

        public AddWindow()
        {
            InitializeComponent();
            verkeersbord = new Verkeersbord();
            AddGrid.DataContext = verkeersbord;
        }

        public void PostSign(Verkeersbord verkeersbord) 
        {
            var json = JsonConvert.SerializeObject(verkeersbord);
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.UploadString(post_URL, "POST", json);
            }
        }

        private void Button_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var item = AddGrid.DataContext as Verkeersbord;
            PostSign(item);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
