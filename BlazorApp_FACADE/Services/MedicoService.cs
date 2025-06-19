using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly HttpClient _http;

        public MedicoService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("CitasApi");
        }

        public async Task<List<Medico>> ObtenerMedicos() =>
            await _http.GetFromJsonAsync<List<Medico>>("api/medicos") ?? new List<Medico>();

        public async Task<Medico?> ObtenerMedicoPorId(int id) =>
            await _http.GetFromJsonAsync<Medico>($"api/medicos/{id}");

        public async Task<bool> AgregarMedico(Medico medico) =>
            (await _http.PostAsJsonAsync("api/medicos", medico)).IsSuccessStatusCode;

        public async Task<bool> EditarMedico(Medico medico)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/medicos/{medico.Id}", medico);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarMedico(int id) =>
            (await _http.DeleteAsync($"api/medicos/{id}")).IsSuccessStatusCode;
    }
}
