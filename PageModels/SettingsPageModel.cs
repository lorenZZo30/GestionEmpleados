using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GestionEmpleadosMaui.PageModels;

public partial class SettingsPageModel : ObservableObject
{
    [RelayCommand]
    void TemaClaro()
    {
        Application.Current.UserAppTheme = AppTheme.Light;
    }

    [RelayCommand]
    void TemaOscuro()
    {
        Application.Current.UserAppTheme = AppTheme.Dark;
    }
}
