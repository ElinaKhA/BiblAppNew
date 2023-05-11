using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace BiblApp
{
    public partial class RegPage : ContentPage
    {
         bool loaded = false;
        public RegPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
           /* object logino = "";
            object passwordo = "";
            object roleo = "";*/
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

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (login.Text == "")
            {
                DisplayAlert("Неуспешно", "Введите логин", "Ок");
            }
            else if (email.Text == "")
            {
                DisplayAlert("Неуспешно", "Введите почту", "Ок");
            }
            else if (password.Text == "" || confirmPassword.Text == "")
            {
                DisplayAlert("Неуспешно", "Введите пароль", "Ок");
            }
            else if (password.Text != confirmPassword.Text)
            {
                DisplayAlert("Неуспешно", "Неправильно повторили пароль", "Ок");
            }
            else if (phone.Text == "")
            {
                DisplayAlert("Неуспешно", "Введите телефон", "Ок");
            }
            else if (role.SelectedItem == "")
            {
                DisplayAlert("Неуспешно", "Укажите роль", "Ок");
            }
            else
            {
                /*      string loginb = login.Text;
                      App.Current.Properties["logino"] = loginb;
                      string passwordb = password.Text;
                      App.Current.Properties["passwordo"] = passwordb;                
                      int roleb = role.SelectedIndex;
                      App.Current.Properties["roleo"] = roleb;*/
                User user = new User();
             //   var user = (User)BindingContext;
              



                if (role.SelectedIndex==0)
                {
                    user.Login = login.Text;
                    user.Email = email.Text;
                    user.Phone = phone.Text;
                    user.Password = password.Text;
                    user.Birth = datePic.Date;
                    user.Role = 0;

                    App.Database.SaveItem(user);
                    DisplayAlert("Успешно", "Вы зарегистрировались как клиент", "Ок");

                    KabinetPage page = new KabinetPage();
                    await Navigation.PushAsync(page);
                    page.DisplayStack();
                }
                else if (role.SelectedIndex == 1)
                {
                    user.Login = login.Text;
                    user.Email = email.Text;
                    user.Phone = phone.Text;
                    user.Password = password.Text;
                    user.Birth = datePic.Date;
                    user.Role = 1;
                    App.Database.SaveItem(user);

                    DisplayAlert("Успешно", "Вы зарегистрировались как библиотекарь", "Ок");

                    KabinetPage page = new KabinetPage();
                    await Navigation.PushAsync(page);
                    page.DisplayStack();
                }
                else if (role.SelectedIndex == 2)
                {
                    user.Login = login.Text;
                    user.Email = email.Text;
                    user.Phone = phone.Text;
                    user.Password = password.Text;
                    user.Birth = datePic.Date;
                    user.Role = 2;
                    App.Database.SaveItem(user);

                    DisplayAlert("Успешно", "Вы зарегистрировались как администратор", "Ок");

                    AdminPage page = new AdminPage();
                    await Navigation.PushAsync(page);
                    page.DisplayStack();
                }

            }
        
        }
        

        private void Theme_OnButtonClicked(object sender, System.EventArgs e)
        {
            //int k = 0;
            //k++;
            if (BackgroundColor == Color.White)
            {
                BackgroundColor = Color.Black;
                regLabel.TextColor = Color.White;
                header.TextColor = Color.White;
                email.TextColor = Color.White;
                password.TextColor = Color.White;
                confirmPassword.TextColor = Color.White;
                phone.TextColor = Color.White;
                login.TextColor = Color.White;
                dateLable.TextColor = Color.White;
                role.TextColor = Color.White;
                datePic.TextColor = Color.White;
            }
            else 
            {
                BackgroundColor = Color.White;
                regLabel.TextColor = Color.Black;
                header.TextColor = Color.Black;
                email.TextColor = Color.Black;
                password.TextColor = Color.Black;
                confirmPassword.TextColor = Color.Black;
                phone.TextColor = Color.Black;
                login.TextColor = Color.Black;
                dateLable.TextColor = Color.Black;
                role.TextColor = Color.Black;
                datePic.TextColor = Color.Black;
            }
        }
        private void Exit_OnButtonClicked(object sender, System.EventArgs e)
        {
            Thread.CurrentThread.Abort();
        }

        private async void authbtn_Clicked(object sender, EventArgs e)
        {
            AuthorizationPage page = new AuthorizationPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }
    }
}