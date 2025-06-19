using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface IDetallePagoService
    {
        Task<List<DetallePago>> ObtenerDetallesPorPago(int pagoId);
        Task<bool> AgregarDetalle(DetallePago detalle);
    }
}
