using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosMaui.Models;
using GestionEmpleadosMaui.Pages;
using GestionEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestionEmpleadosMaui.PageModels
{
    public partial class EmpleadosPageModel(EmpleadoService service) : ObservableObject
    {
        private readonly EmpleadoService _service = service;

        [ObservableProperty]
        private ObservableCollection<Empleado> _empleados = new();

        [ObservableProperty]
        private Empleado _empleadoSeleccionado;

        public async Task LoadDataAsync()
        {
            var lista = await _service.RefreshDataAsync();
            Empleados.Clear();
            foreach (var empleado in lista)
                Empleados.Add(empleado);
        }

        partial void OnEmpleadoSeleccionadoChanged(Empleado? value)
        {
            if (value == null) return;

            // Navegar a la página de detalle
            Shell.Current.GoToAsync(nameof(EmpleadoDetailPage), new Dictionary<string, object>
            {
                { "Item", value }
            });

            // Limpiar
            EmpleadoSeleccionado = null;
        }
    }
}