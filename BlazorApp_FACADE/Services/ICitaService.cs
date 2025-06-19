using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface ICitaService
    {
        Task<List<Cita>> ObtenerCitas();
        Task<Cita?> ObtenerCitaPorId(int id);
        Task<bool> AgregarCita(Cita cita);
        Task<bool> EditarCita(Cita cita);
        Task<bool> EliminarCita(int id);
    }
}
