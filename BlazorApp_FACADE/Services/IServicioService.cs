using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface IServicioService
    {
        Task<List<Servicio>> ObtenerServicios();
        Task<Servicio?> ObtenerServicioPorId(int id);
        Task<bool> AgregarServicio(Servicio servicio);
        Task<bool> EditarServicio(Servicio servicio);
        Task<bool> EliminarServicio(int id);
    }
}
