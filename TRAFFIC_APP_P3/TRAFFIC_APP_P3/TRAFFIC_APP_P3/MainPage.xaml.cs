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
    public partial class MainPage : ContentPage
    {
        private string base_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";
        public List<Verkeersbord> verkeersborden;

        public MainPage()
        {
            filter_picker.Items.Add("vorm");
            filter_picker.Items.Add("type");
            if (verkeersborden == null)
            {
                verkeersborden = LoadSigns();
            }
            this.BindingContext = verkeersborden;
            InitializeComponent();
            AllSigns.ItemsSource = verkeersborden;
        }

        private List<Verkeersbord> LoadSigns()
        {
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(base_URL)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            List<Verkeersbord> verkeersborden = JsonConvert.DeserializeObject<List<Verkeersbord>>(result);
            return verkeersborden;
        }

        private void AllSigns_MouseDoubleClick()
        {
            var item = AllSigns.SelectedItem as Verkeersbord;
            DetailPage detailPage = new DetailPage(item.id);
            Navigation.PushAsync(detailPage);
        }

        //handle double click add button
        private void Button_MouseEnter()
        {
            AddPage addPage = new AddPage();
            Navigation.PushAsync(addPage);
        }

        //handle double click filter
        private void Pick()
        {
            if (filter_picker.SelectedIndex == -1)
            {
                AllSigns.ItemsSource = verkeersborden;
            }
            else
            {
                if (filter_picker.SelectedIndex == 0)
                {
                    List<Verkeersbord> filteredList = verkeersborden.FindAll(delegate(Verkeersbord obj) { return obj.type == FilterBox.Text; });
                    AllSigns.ItemsSource = filteredList;
                }
                else
                {
                    List<Verkeersbord> filteredList = verkeersborden.FindAll(delegate(Verkeersbord obj) { return obj.vorm == FilterBox.Text; });
                    AllSigns.ItemsSource = filteredList;
                }

            }

        }
    }
}
