using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface IEvolucionService
    {
        Task<List<EvolucionMedica>> ObtenerEvolucionesPorCita(int citaId);
        Task<bool> AgregarEvolucion(EvolucionMedica evolucion);
    }
}
