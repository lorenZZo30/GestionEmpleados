using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosMaui.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleadosMaui.PageModels
{
    [QueryProperty(nameof(Departamento), "Item")]
    public partial class DepartamentoDetailPageModel : ObservableObject
    {
        [ObservableProperty] private Departamento? _departamento;

        [RelayCommand]
        async Task Volver() => await Shell.Current.GoToAsync("..");
    }
}
