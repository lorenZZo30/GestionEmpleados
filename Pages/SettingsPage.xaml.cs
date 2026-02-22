using GestionEmpleadosMaui.PageModels;

namespace GestionEmpleadosMaui.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}