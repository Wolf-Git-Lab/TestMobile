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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLogin.Text) || string.IsNullOrEmpty(TxtPassword.Text))
                DisplayAlert("Ошибка", "Поле или поля не должны быть пустыми", "Ок");
            else
            {
                try
                {
                    WebClient avtorisation = new WebClient();
                    var response = avtorisation.DownloadString($"http://192.168.1.54:8000/api/GetAvtorisation?login={TxtLogin.Text}&password={TxtPassword.Text}");
                    List<Class.DannyePacientov> dannyePacientovs = JsonConvert.DeserializeObject<List<Class.DannyePacientov>>(response);
                    foreach (var item in dannyePacientovs)
                    {
                        Dannye.Id = item.Id;
                        Dannye.Login = item.Login;
                        Dannye.Password = item.Password;
                        Dannye.Email = item.Email;
                        Dannye.Phone = item.Phone;
                        Dannye.DateRojdeniy = item.DateRojdeniy;
                    }
                    Navigation.PushAsync(new AccauntPage());
                }
                catch (Exception)
                {
                    DisplayAlert("Error", "Неверный логин или пароль", "Ок");
                }
            }
        }
    }
}