using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceEditPage : ContentPage
    {
        private Class.Services Services { get; set; }
        public ServiceEditPage()
        {
            InitializeComponent();
            //Services = services;
            //TxtTitle.Text = Services.Service;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {

        }
    }
}