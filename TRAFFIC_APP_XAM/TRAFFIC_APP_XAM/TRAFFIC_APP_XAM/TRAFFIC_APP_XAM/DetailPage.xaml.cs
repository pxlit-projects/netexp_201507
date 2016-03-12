using Business_objects;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TRAFFIC_APP_XAM
{
    public partial class DetailPage : ContentPage
    {
        private string base_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";

        public DetailPage(int id)
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
            MainPage mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }
    }
}
