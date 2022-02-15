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
    public partial class AccauntPage : ContentPage
    {
        public AccauntPage()
        {
            InitializeComponent();
            LblID.Text = Dannye.Id.ToString();
            LblLogin.Text = Dannye.Login;
            LblPassword.Text = Dannye.Password;
            LblEmail.Text = Dannye.Email;
            LblPhone.Text = Dannye.Phone;
            LblLet.Text = Year(Dannye.DateRojdeniy).ToString();
        }

        public int Year(DateTime date)
        {
            int year = date.Year;
            int dateYear = DateTime.Now.Year - year;
            return dateYear;
        }

        private void BtnEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditPage());
        }
    }
}