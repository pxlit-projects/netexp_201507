using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TRAFFIC_APP_P3
{
    public partial class DetailPage : ContentPage
    {
        private string base_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";

        public DetailPage(int id)
        {
            this.BindingContext = GetSignleSign(id);

            InitializeComponent();

        }

        private Verkeersbord GetSignleSign(int id)
        {
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(base_URL)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            Verkeersbord verkeersbord = JsonConvert.DeserializeObject<Verkeersbord>(result);

            return verkeersbord;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainPage mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }
    }
}
