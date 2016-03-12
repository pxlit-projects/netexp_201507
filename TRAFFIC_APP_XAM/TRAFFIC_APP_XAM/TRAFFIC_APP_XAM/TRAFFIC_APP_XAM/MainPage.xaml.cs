using Business_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace TRAFFIC_APP_XAM
{
    public partial class MainPage : ContentPage
    {

        private string base_URL = "http://antwerpseverkeersborden.azurewebsites.net/api/verkeersbords/";
        public List<Verkeersbord> verkeersborden;

        public MainPage()
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
        private void Button_MouseDoubleClick()
        {
            if (FilterBox.Text != "")
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
