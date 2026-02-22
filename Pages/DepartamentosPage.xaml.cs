using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class DepartamentosPage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is DepartamentosPageModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }
    public DepartamentosPage(DepartamentosPageModel model)
    {
        OnAppearing();
        InitializeComponent();
        BindingContext = model;
    }
}