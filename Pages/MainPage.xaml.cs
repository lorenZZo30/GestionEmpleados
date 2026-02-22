using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages
{
    public partial class MainPage : ContentPage
    {
            public MainPage(MainPageModel model) // <-- Inyección automática
            {
                InitializeComponent();
                BindingContext = model; // <-- Aquí asignas el cerebro a la vista
            }

            protected override async void OnAppearing()
            {
                base.OnAppearing();
                // Llamamos a la carga de datos cada vez que se ve la página
                if (BindingContext is MainPageModel viewModel)
                {
                    await viewModel.LoadDataAsync();
                }
            }
    }
}
