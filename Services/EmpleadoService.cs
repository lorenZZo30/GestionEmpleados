using GestionEmpleadosMaui.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace GestionEmpleadosMaui.Services
{
    public class EmpleadoService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<Empleado> Empleados { get; private set; }

        public EmpleadoService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                WriteIndented = true
            };
        }

        public async Task<List<Empleado>> RefreshDataAsync()
        {
            Empleados = new List<Empleado>();

            Uri uri = new Uri("http://localhost:8000/empleados");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Empleados = JsonSerializer.Deserialize<List<Empleado>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Empleados;
        }

        public async Task SaveEmpleadoAsync(Empleado empleado, bool isNewItem = false)
        {
            Uri uri = new Uri("http://localhost:8000/empleados");

            try
            {
                string json = JsonSerializer.Serialize<Empleado>(empleado, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    Uri putUri = new Uri($"http://10.0.2.2:8000/empleados/{empleado.Id}");
                    response = await _client.PutAsync(putUri, content);
                }

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tEmpleado guardado correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            Uri uri = new Uri($"http://localhost:8000/empleados/{id}");

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\Empleado eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
