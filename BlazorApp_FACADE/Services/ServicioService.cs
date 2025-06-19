using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class ServicioService : IServicioService
    {
        private readonly HttpClient _http;

        public ServicioService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("CitasApi");
        }

        public async Task<List<Servicio>> ObtenerServicios() =>
            await _http.GetFromJsonAsync<List<Servicio>>("api/servicios") ?? new List<Servicio>();

        public async Task<Servicio?> ObtenerServicioPorId(int id) =>
            await _http.GetFromJsonAsync<Servicio>($"api/servicios/{id}");

        public async Task<bool> AgregarServicio(Servicio servicio) =>
            (await _http.PostAsJsonAsync("api/servicios", servicio)).IsSuccessStatusCode;

        public async Task<bool> EditarServicio(Servicio servicio)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/servicios/{servicio.Id}", servicio);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarServicio(int id) =>
            (await _http.DeleteAsync($"api/servicios/{id}")).IsSuccessStatusCode;
    }
}
