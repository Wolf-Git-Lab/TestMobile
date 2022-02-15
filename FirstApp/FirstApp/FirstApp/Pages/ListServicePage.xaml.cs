using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListServicePage : ContentPage
    {
        public ListServicePage()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
            var response = webClient.DownloadString("http://192.168.1.54:8000/api/Services");
            LstService.ItemsSource = JsonConvert.DeserializeObject<List<Class.Services>>(response);

        }

        private void LstService_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ServiceEditPage());
        }
    }
}