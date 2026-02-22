using GestionEmpleadosMaui.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace GestionEmpleadosMaui.Services
{
    public class DepartamentoService
    {
        HttpClient _client;
        private static readonly JsonSerializerOptions _serializerOptions 
            = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                WriteIndented = true
                };


        public List<Departamento> Departamentos { get; private set; }

        public DepartamentoService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Departamento>> RefreshDataAsync()
        {
            Departamentos = new List<Departamento>();

            Uri uri = new Uri("http://localhost:8000/departamentos/");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Departamentos = JsonSerializer.Deserialize<List<Departamento>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Departamentos;
        }

        public async Task SaveDepartamentoAsync(Departamento departamento, bool isNewItem = false)
        {
            Uri uri = new Uri("http://localhost:8000/departamentos");

            try
            {
                string json = JsonSerializer.Serialize<Departamento>(departamento, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    Uri putUri = new Uri($"http://10.0.2.2:8000/departamentos/{departamento.Id}");
                    response = await _client.PutAsync(putUri, content);
                }

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\Departamento guardado correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Uri uri = new Uri($"http://localhost:8000/departamentos/{id}");

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\Departamento eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
