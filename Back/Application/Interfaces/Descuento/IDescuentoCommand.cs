using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDescuentoCommand
    {
        Task<Descuento> CrearDescuento(Descuento descuento);
        Task<Descuento> ModificarDescuento(Descuento descuento);
        Task<Descuento> EliminarDescuento(Descuento descuento);
    }
}
