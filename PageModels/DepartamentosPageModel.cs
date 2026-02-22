using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosMaui.Models;
using GestionEmpleadosMaui.Pages;
using GestionEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestionEmpleadosMaui.PageModels
{
    public partial class DepartamentosPageModel(DepartamentoService service) : ObservableObject
    {
        private readonly DepartamentoService _service = service;

        [ObservableProperty]
        private ObservableCollection<Departamento> _departamentos = new();

        [ObservableProperty]
        private Departamento _departamentoSeleccionado;

        public async Task LoadDataAsync()
        {
            var lista = await _service.RefreshDataAsync();
            Departamentos.Clear();
            foreach (var departamento in lista)
                Departamentos.Add(departamento);
        }

        partial void OnDepartamentoSeleccionadoChanged(Departamento? value)
        {
            if (value == null) return;

            // Navegar a la página de detalle
            Shell.Current.GoToAsync(nameof(DepartamentoDetailPage), new Dictionary<string, object>
            {
                { "Item", value }
            });

            // Limpiar
            DepartamentoSeleccionado = null;
        }
    }
}
