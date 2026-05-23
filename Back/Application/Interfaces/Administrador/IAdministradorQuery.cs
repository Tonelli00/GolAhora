

using Application.DTOs.Request.Cliente;
using Application.DTOs.Response;

namespace Application.Interfaces.Administrador
{
    public interface IAdministradorQuery
    {
        Task<Domain.Entities.Administrador> Login(string correo,CancellationToken ct = default);
    }
}
