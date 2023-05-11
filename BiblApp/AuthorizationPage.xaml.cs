using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NavigationPage = Xamarin.Forms.NavigationPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace BiblApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthorizationPage : ContentPage
	{
        bool loaded = false;
        public AuthorizationPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (loaded == false)
            {
                DisplayStack();
                loaded = true;
            }
        }
        protected internal void DisplayStack()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            stackLabel.Text = "";
            foreach (Xamarin.Forms.Page p in navPage.Navigation.NavigationStack)
            {
                stackLabel.Text += p.Title + "\n";
            }
        }
        private async void regbtn_Clicked(object sender, EventArgs e)
        {
            RegPage page = new RegPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }

        private async void kabinetButton_Clicked(object sender, EventArgs e)
        {
              /*  string log = App.Current.Properties["logino"].ToString();
                string pass = App.Current.Properties["passwordo"].ToString();
                int role = (int)App.Current.Properties["roleo"]; */
         var users = App.Database.GetItems();
           User user = users.Where(x=> x.Login == login.Text).FirstOrDefault();

           
            if (login.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите логин", "Ок");
            }
            else if (password.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите пароль", "Ок");
            }
            else if (user.Login != login.Text)
            {
                DisplayAlert("Неуспешно", "Неверный логин", "Ок");
            }
            else if (user.Password != password.Text)
            {
                DisplayAlert("Неуспешно", "Неверный пароль", "Ок");
            }
            else
            {
                if (user.Role == 0)
                {
                   
                    DisplayAlert("Успешно", "Вы вошли как клиент", "Ок");
                    KabinetPage page = new KabinetPage();
                    await Navigation.PushAsync(page);
                    page.DisplayStack();
                }
                else if(user.Role == 1)
                {

                    DisplayAlert("Успешно", "Вы вошли как библиотекарь", "Ок");
                    KabinetPage page = new KabinetPage();
                    await Navigation.PushAsync(page);
                    page.DisplayStack();
                }  
                else if(user.Role == 2)
                {
                    DisplayAlert("Успешно", "Вы вошли как администратор", "Ок");
                    AdminPage page = new AdminPage();
                    await Navigation.PushAsync(page);
                    page.DisplayStack();
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Thread.CurrentThread.Abort();
        }
    }
}