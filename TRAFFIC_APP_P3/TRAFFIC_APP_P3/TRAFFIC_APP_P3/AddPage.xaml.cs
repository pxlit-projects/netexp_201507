using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TRAFFIC_APP_P3
{
    public partial class AddPage : ContentPage
    {
        private string post_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";

        public Verkeersbord verkeersbord;

        public AddPage()
        {
            this.BindingContext = verkeersbord;
            InitializeComponent();
            verkeersbord = new Verkeersbord();
        }

        public void PostSign(Verkeersbord verkeersbord)
        {
            var client = new HttpClient();
            var response = client.PostAsync(post_URL, new StringContent(JsonConvert.SerializeObject(verkeersbord).ToString(),
                Encoding.UTF8, "application/json")).Result;
        }

        private void Button_MouseDoubleClick_1()
        {
            var item = AddGrid.BindingContext as Verkeersbord;
            PostSign(item);
            MainPage mainPage = new MainPage();
        }
    }
}
