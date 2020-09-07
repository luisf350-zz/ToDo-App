using System;
using ToDo.App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private async void BtnGuardar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var item = new TodoItem
                {
                    Name = nombre.Text,
                    Description = descripcion.Text
                };

                var result = await App.Context.InsertItemAsycn(item);
                if (result == 1)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la tarea", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}