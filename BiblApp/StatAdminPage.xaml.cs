using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiblApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatAdminPage : ContentPage
    {
        Label stackLabel;
        public StatAdminPage()
        {
            Title = "Page Stat Admin";


            Button regBtn = new Button { Text = "Назад" };
            regBtn.Clicked += GoToBack;

            stackLabel = new Label();
            Content = new StackLayout { Children = { regBtn, stackLabel } };
        }
        protected internal void DisplayStack()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            stackLabel.Text = "";
            foreach (Page p in navPage.Navigation.NavigationStack)
            {
                stackLabel.Text += p.Title + "\n";
            }
        }

        // Переход обратно к регистрации
        private async void GoToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
        }
    }
}