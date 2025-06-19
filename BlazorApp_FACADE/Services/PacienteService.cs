using System.Net.Http.Json;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly HttpClient _http;

        public PacienteService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("CitasApi");
        }


        public async Task<List<Paciente>> ObtenerPacientes() =>
            await _http.GetFromJsonAsync<List<Paciente>>("api/pacientes") ?? new List<Paciente>();

        public async Task<Paciente?> ObtenerPacientePorId(int id) =>
            await _http.GetFromJsonAsync<Paciente>($"api/pacientes/{id}");

        public async Task<bool> AgregarPaciente(Paciente paciente) =>
            (await _http.PostAsJsonAsync("api/pacientes", paciente)).IsSuccessStatusCode;

        public async Task<bool> EditarPaciente(Paciente paciente)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/pacientes/{paciente.Id}", paciente);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarPaciente(int id) =>
            (await _http.DeleteAsync($"api/pacientes/{id}")).IsSuccessStatusCode;
    }
}
