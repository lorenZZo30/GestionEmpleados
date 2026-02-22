using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class SedesPage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is SedesPageModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }
    public SedesPage(SedesPageModel model)
    {
        OnAppearing();
        InitializeComponent();
        BindingContext = model;
    }
}