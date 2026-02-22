using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class EmpleadosPage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is EmpleadosPageModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }
    public EmpleadosPage(EmpleadosPageModel model)
    {
        OnAppearing();
        InitializeComponent();
        BindingContext = model;
    }
}