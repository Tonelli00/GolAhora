using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IDescuentoService
    {
        Task<DescuentoResponse> CreateDescuento(CrearDescuentoRequest request);
        Task<DescuentoResponse> UpdateDescuento(ModificarDescuentoRequest request, int id);
        Task<DescuentoResponse> GetDescuentoById(int id);
        Task<List<DescuentoResponse>> GetAllDescuentos();
        Task<DescuentoResponse> DeleteDescuento(int id);
        Task<DescuentoResponse> GetDescuentoActivoPorTipo(string tipo);
    }
}
