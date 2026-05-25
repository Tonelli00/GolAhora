
using Application.DTOs.Request.Administrador;
using Application.DTOs.Request.Cliente;
using Application.DTOs.Response;

namespace Application.Interfaces.Administrador
{
    public interface IAdministradorService
    {
        Task<AdministradorResponse> RegistrarAdministrador(CrearAdministradorRequest request);
        Task<AdministradorResponse> Login(LoginRequest request);

    }
}
