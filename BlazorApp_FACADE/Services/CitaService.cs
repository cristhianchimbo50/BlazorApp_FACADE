using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class CitaService : ICitaService
    {
        private readonly HttpClient _http;

        public CitaService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("CitasApi");
        }

        public async Task<List<Cita>> ObtenerCitas() =>
            await _http.GetFromJsonAsync<List<Cita>>("api/citas") ?? new List<Cita>();

        public async Task<Cita?> ObtenerCitaPorId(int id) =>
            await _http.GetFromJsonAsync<Cita>($"api/citas/{id}");

        public async Task<bool> AgregarCita(Cita cita) =>
            (await _http.PostAsJsonAsync("api/citas", cita)).IsSuccessStatusCode;

        public async Task<bool> EditarCita(Cita cita)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/citas/{cita.Id}", cita);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarCita(int id) =>
            (await _http.DeleteAsync($"api/citas/{id}")).IsSuccessStatusCode;
    }
}
