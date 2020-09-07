using System;
using ToDo.App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await App.Context.GetItemsAsync();
            lista_tareas.ItemsSource = items;
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void BtnDelete_OnClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación", "Esta seguro de eliminar el elemento?","Si", "No"))
            {
                var item = (TodoItem) (sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(item);
                if (result == 1)
                {
                    LoadItems();
                }
            }
        }
    }
}