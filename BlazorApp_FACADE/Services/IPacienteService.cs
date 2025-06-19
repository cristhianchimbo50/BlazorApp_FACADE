using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface IPacienteService
    {
        Task<List<Paciente>> ObtenerPacientes();
        Task<Paciente?> ObtenerPacientePorId(int id);
        Task<bool> AgregarPaciente(Paciente paciente);
        Task<bool> EditarPaciente(Paciente paciente);
        Task<bool> EliminarPaciente(int id);
    }
}
