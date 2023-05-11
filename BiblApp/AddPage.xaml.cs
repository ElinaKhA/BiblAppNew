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
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private async void kabinetButton_Clicked(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Name = name.Text;
            book.Author = avtor.Text;
            book.Year = Convert.ToInt32(year.Text);
            book.Type = type.Text;
            App.Database.SaveBook(book);

            await Navigation.PopAsync();

        //    NavigationPage navPage = (NavigationPage)App.Current.MainPage;
        }
    }
}