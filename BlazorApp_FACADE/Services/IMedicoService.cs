using BlazorApp_FACADE.Models;

namespace BlazorApp_FACADE.Services
{
    public interface IMedicoService
    {
        Task<List<Medico>> ObtenerMedicos();
        Task<Medico?> ObtenerMedicoPorId(int id);
        Task<bool> AgregarMedico(Medico medico);
        Task<bool> EditarMedico(Medico medico);
        Task<bool> EliminarMedico(int id);
    }
}
