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
    public partial class AdminPage : ContentPage
    {
        Label stackLabel;
        public AdminPage()
        {
            Title = "Page Admin";
            Button redClientBtn = new Button { Text = "Редактировать пользователя" };
            redClientBtn.Clicked += GoToForward;

            Button statBtn = new Button { Text = "Посмотреть статистику" };
            statBtn.Clicked += GoToForwardStat;
            Button booksBtn = new Button { Text = "Посмотреть книги" };
            booksBtn.Clicked += GoToForwardBooks;

            Button regBtn = new Button { Text = "Назад" };
            regBtn.Clicked += GoToBack;

            stackLabel = new Label();
            Content = new StackLayout { Children = { redClientBtn, statBtn,booksBtn, regBtn, stackLabel } };
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
        // Переход вперед на страницу с редактированием клиентов
        private async void GoToForward(object sender, EventArgs e)
        {
            EditClientPage page = new EditClientPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }
        // Переход вперед на страницу статистики
        private async void GoToForwardStat(object sender, EventArgs e)
        {
            StatAdminPage page = new StatAdminPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }
        // Переход вперед на страницу с книгами
        private async void GoToForwardBooks(object sender, EventArgs e)
        {
            BooksPage page = new BooksPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }
        // Переход обратно к регистрации
        private async void GoToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((RegPage)navPage.CurrentPage).DisplayStack();
        }
    }
}