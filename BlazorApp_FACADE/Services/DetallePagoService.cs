using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class DetallePagoService : IDetallePagoService
    {
        private readonly HttpClient _http;

        public DetallePagoService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("FacturacionApi");
        }

        public async Task<List<DetallePago>> ObtenerDetallesPorPago(int pagoId) =>
            await _http.GetFromJsonAsync<List<DetallePago>>($"api/detallespago/pago/{pagoId}") ?? new List<DetallePago>();

        public async Task<bool> AgregarDetalle(DetallePago detalle) =>
            (await _http.PostAsJsonAsync("api/detallespago", detalle)).IsSuccessStatusCode;
    }
}
