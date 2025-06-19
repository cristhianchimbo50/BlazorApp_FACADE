using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface IPagoService
    {
        Task<List<Pago>> ObtenerPagos();
        Task<List<Pago>> ObtenerPagosPorCita(int citaId);
        Task<Pago?> ObtenerPagoPorId(int id);
        Task<bool> AgregarPago(Pago pago);
    }
}
