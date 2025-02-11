using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public class CitasFacadeService
    {
        private readonly HttpClient _httpClient;

        public CitasFacadeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener listas
        public async Task<List<Paciente>> ObtenerPacientes() =>
            await _httpClient.GetFromJsonAsync<List<Paciente>>("api/pacientes") ?? new List<Paciente>();

        public async Task<List<Medico>> ObtenerMedicos() =>
            await _httpClient.GetFromJsonAsync<List<Medico>>("api/medicos") ?? new List<Medico>();

        public async Task<List<Cita>> ObtenerCitas() =>
            await _httpClient.GetFromJsonAsync<List<Cita>>("api/citas") ?? new List<Cita>();

        // Agregar registros
        public async Task<bool> AgregarPaciente(Paciente paciente) =>
            (await _httpClient.PostAsJsonAsync("api/pacientes", paciente)).IsSuccessStatusCode;

        public async Task<bool> AgregarMedico(Medico medico) =>
            (await _httpClient.PostAsJsonAsync("api/medicos", medico)).IsSuccessStatusCode;

        public async Task<bool> AgregarCita(Cita cita) =>
            (await _httpClient.PostAsJsonAsync("api/citas", cita)).IsSuccessStatusCode;

        // Editar registros (Nuevo)
        public async Task<bool> EditarPaciente(int id, Paciente paciente) =>
            (await _httpClient.PutAsJsonAsync($"api/pacientes/{id}", paciente)).IsSuccessStatusCode;

        public async Task<bool> EditarMedico(int id, Medico medico) =>
            (await _httpClient.PutAsJsonAsync($"api/medicos/{id}", medico)).IsSuccessStatusCode;

        public async Task<bool> EditarCita(int id, Cita cita) =>
            (await _httpClient.PutAsJsonAsync($"api/citas/{id}", cita)).IsSuccessStatusCode;

        // Eliminar registros
        public async Task<bool> EliminarPaciente(int id) =>
            (await _httpClient.DeleteAsync($"api/pacientes/{id}")).IsSuccessStatusCode;

        public async Task<bool> EliminarMedico(int id) =>
            (await _httpClient.DeleteAsync($"api/medicos/{id}")).IsSuccessStatusCode;

        public async Task<bool> EliminarCita(int id) =>
            (await _httpClient.DeleteAsync($"api/citas/{id}")).IsSuccessStatusCode;


        public async Task<bool> EditarPaciente(Paciente paciente)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"pacientes/{paciente.Id}", paciente);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editando paciente: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditarMedico(Medico medico)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"medicos/{medico.Id}", medico);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editando médico: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EditarCita(Cita cita)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"citas/{cita.Id}", cita);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editando cita: {ex.Message}");
                return false;
            }
        }

    }
}
