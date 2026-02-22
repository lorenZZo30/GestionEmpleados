using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class DepartamentoDetailPage : ContentPage
{
    public DepartamentoDetailPage(DepartamentoDetailPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}