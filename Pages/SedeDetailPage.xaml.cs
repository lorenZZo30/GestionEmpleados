using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class SedeDetailPage : ContentPage
{
    public SedeDetailPage(SedeDetailPageModel model) 
    {
        InitializeComponent();
        BindingContext = model;
    }
}