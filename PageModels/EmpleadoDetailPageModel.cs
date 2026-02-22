using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosMaui.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleadosMaui.PageModels
{
    [QueryProperty(nameof(Empleado), "Item")]
    public partial class EmpleadoDetailPageModel : ObservableObject
    {
        [ObservableProperty] private Empleado? _empleado;

        [RelayCommand]
        async Task Volver() => await Shell.Current.GoToAsync("..");
    }
}
