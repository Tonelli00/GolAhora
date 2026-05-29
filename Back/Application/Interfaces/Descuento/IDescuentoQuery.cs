using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDescuentoQuery
    {
        Task<Descuento> GetDescuentoById(int idDescuento);
        Task<List<Descuento>> GetAllDescuentos();
        Task<Descuento> GetDescuentoActivoPorTipo(string tipoDescuento);
    }
}
