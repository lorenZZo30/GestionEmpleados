using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosMaui.Models;
using GestionEmpleadosMaui.Pages;
using GestionEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestionEmpleadosMaui.PageModels
{
    public partial class SedesPageModel : ObservableObject
    {
        private readonly SedeService _service;

        [ObservableProperty]
        private ObservableCollection<Sede> _sedes = new();

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private Sede _sedeSeleccionada;

        public SedesPageModel(SedeService service)
        {
            _service = service;
        }

        public async Task LoadDataAsync()
        {
            IsRefreshing = true;
            try
            {
                var lista = await _service.RefreshDataAsync();
                Sedes.Clear();
                foreach (var sede in lista)
                    Sedes.Add(sede);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        partial void OnSedeSeleccionadaChanged(Sede? value)
        {
            if (value == null) return;

            // Navegar a la página de detalle
            Shell.Current.GoToAsync(nameof(SedeDetailPage), new Dictionary<string, object>
            {
                { "Item", value }
            });

            // Limpiar
            SedeSeleccionada = null;
        }
    }
}