using CommunityToolkit.Mvvm.ComponentModel;
using GestionEmpleadosMaui.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleadosMaui.PageModels
{
    public partial class MainPageModel : ObservableObject
    {
        private readonly EmpleadoService _empleadoService;
        private readonly DepartamentoService _departamentoService;
        private readonly SedeService _sedeService;

        [ObservableProperty] private int _totalEmpleados;
        [ObservableProperty] private int _totalDepartamentos;
        [ObservableProperty] private int _totalSedes;

        public MainPageModel(
            EmpleadoService empleadoService,
            DepartamentoService departamentoService,
            SedeService sedeService)
        {
            _empleadoService = empleadoService;
            _departamentoService = departamentoService;
            _sedeService = sedeService;
        }

        public async Task LoadDataAsync()
        {
            TotalEmpleados = (await _empleadoService.RefreshDataAsync()).Count;
            TotalDepartamentos = (await _departamentoService.RefreshDataAsync()).Count;
            TotalSedes = (await _sedeService.RefreshDataAsync()).Count;
        }
    }
}
