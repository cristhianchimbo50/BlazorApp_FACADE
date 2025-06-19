using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _http;

        public PagoService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("FacturacionApi");
        }

        public async Task<List<Pago>> ObtenerPagos()
        {
            return await _http.GetFromJsonAsync<List<Pago>>("api/pagos/todos") ?? new();
        }

        public async Task<List<Pago>> ObtenerPagosPorCita(int citaId)
        {
            return await _http.GetFromJsonAsync<List<Pago>>($"api/pagos/cita/{citaId}") ?? new();
        }

        public async Task<Pago?> ObtenerPagoPorId(int id)
        {
            return await _http.GetFromJsonAsync<Pago>($"api/pagos/{id}");
        }

        public async Task<bool> AgregarPago(Pago pago)
        {
            var response = await _http.PostAsJsonAsync("api/pagos", pago);
            return response.IsSuccessStatusCode;
        }
    }
}
