using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TRAFFIC_APP_XAM
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
            /*var json = JsonConvert.SerializeObject(verkeersbord);
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.UploadString(post_URL, "POST", json);
            }*/
            var client = new HttpClient();
            Uri postUri = new Uri(post_URL);
            var content = new PushStreamContent((stream, httpContent, transportContext) =>
            {
                var serializer = new JsonSerializer();
                using (var writer = new StreamWriter(stream))
                {
                    serializer.Serialize(writer, verkeersbord);
                }
            });
            var response = client.PostAsync(postUri, content);
        }

        private void Button_MouseDoubleClick_1()
        {
            var item = AddGrid.BindingContext as Verkeersbord;
            PostSign(item);
            MainPage mainPage = new MainPage();
        }
    }
}
