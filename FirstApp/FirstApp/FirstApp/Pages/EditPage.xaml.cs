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
    public partial class EditPage : ContentPage
    {
        public EditPage()
        {
            InitializeComponent();
            TxtLogin.Text = Dannye.Login;
            TxtPassword.Text = Dannye.Password;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            int id = Dannye.Id;
            if (string.IsNullOrEmpty(TxtLogin.Text))
                DisplayAlert("Error", "Поле логин недолжно быть пустым", "Ок");
            else if (string.IsNullOrEmpty(TxtPassword.Text))
                DisplayAlert("Error", "Поле пароль недолжно быть пустым", "Ок");
            else
            {
                try
                {
                    var edit = new Class.DannyePacientov {Id = id, Login = TxtLogin.Text, Password = TxtPassword.Text, DateRojdeniy = Dannye.DateRojdeniy, Email = Dannye.Email, Phone = Dannye.Phone };
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var response = webClient.UploadString($"http://192.168.1.54:8000/api/DannyePacientovs/{id}", "PUT", JsonConvert.SerializeObject(edit));
                    Dannye.Login = TxtLogin.Text;
                    Dannye.Password = TxtPassword.Text;
                    DisplayAlert("Уведомление", "Данные успешно редактированы", "Ок");
                    Navigation.PushAsync(new AccauntPage());
            }
                catch (Exception)
            {
                DisplayAlert("Error", "Что-то пошло не так :(", "Ок");
            }
        }
        }
    }
}