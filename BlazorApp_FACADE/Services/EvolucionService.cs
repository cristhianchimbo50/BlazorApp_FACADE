using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class EvolucionService : IEvolucionService
    {
        private readonly HttpClient _http;

        public EvolucionService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("CitasApi");
        }

        public async Task<List<EvolucionMedica>> ObtenerEvolucionesPorCita(int citaId) =>
            await _http.GetFromJsonAsync<List<EvolucionMedica>>($"api/evoluciones/cita/{citaId}") ?? new List<EvolucionMedica>();

        public async Task<bool> AgregarEvolucion(EvolucionMedica evolucion) =>
            (await _http.PostAsJsonAsync("api/evoluciones", evolucion)).IsSuccessStatusCode;
    }
}
