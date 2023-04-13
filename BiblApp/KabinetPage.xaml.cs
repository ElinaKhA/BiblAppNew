using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiblApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KabinetPage : ContentPage
    {
        Image img;
        Label stackLabel;
        public KabinetPage()
        {
            Title = "Page Kabinet";
            Button booksBtn = new Button { Text = "К списку книг" };
            booksBtn.Clicked += GoToForward;

            Button addBtn = new Button { Text = "Добавить фото" };
            addBtn.Clicked += GoToForwardAddPhoto;
            Button takeBtn = new Button { Text = "Сделать фото" };
            takeBtn.Clicked += GoToForwardTakePhoto;


            Button regBtn = new Button { Text = "Назад" };
            regBtn.Clicked += GoToBack;
            img = new Image();

            stackLabel = new Label();
            Content = new StackLayout { Children = { booksBtn, addBtn, takeBtn, regBtn, stackLabel, img }  };
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
        // Переход вперед на страницу с книгами
        private async void GoToForward(object sender, EventArgs e)
        {
            BooksPage page = new BooksPage();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }
        private async void GoToForwardAddPhoto(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }

        }
        private async void GoToForwardTakePhoto(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
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