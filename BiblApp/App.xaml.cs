using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiblApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

         //   MainPage = new RegPage();
            MainPage = new NavigationPage(new RegPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
