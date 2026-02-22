using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class EmpleadoDetailPage : ContentPage
{
    public EmpleadoDetailPage(EmpleadoDetailPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}