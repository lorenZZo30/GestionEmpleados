using GestionEmpleadosMaui.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace GestionEmpleadosMaui.Services
{
    public class SedeService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<Sede> Sedes { get; private set; }

        public SedeService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                WriteIndented = true
            };
        }

        public async Task<List<Sede>> RefreshDataAsync()
        {
            Sedes = new List<Sede>();

            Uri uri = new Uri("http://localhost:8000/sedes/");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Sedes = JsonSerializer.Deserialize<List<Sede>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Sedes;
        }

        public async Task SaveSedeAsync(Sede sede, bool isNewItem = false)
        {
            Uri uri = new Uri("http://localhost:8000/sedes");

            try
            {
                string json = JsonSerializer.Serialize<Sede>(sede, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    Uri putUri = new Uri($"http://10.0.2.2:8000/sedes/{sede.Id}");
                    response = await _client.PutAsync(putUri, content);
                }

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\Sede guardada correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteSedeAsync(int id)
        {
            Uri uri = new Uri($"http://localhost:8000/sedes/{id}");

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\Sede eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
