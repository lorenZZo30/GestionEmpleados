using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosMaui.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleadosMaui.PageModels
{
    [QueryProperty(nameof(Sede), "Item")]
    public partial class SedeDetailPageModel : ObservableObject
    {
        [ObservableProperty] private Sede? _sede;

        [RelayCommand]
        async Task Volver() => await Shell.Current.GoToAsync("..");
    }
}
