
using Application.DTOs.Request.Cliente;
using Application.DTOs.Response;
using Application.Interfaces.Administrador;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class AdministradorQuery : IAdministradorQuery
    {
        private readonly AppDbContext _context;

        public AdministradorQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Administrador> Login(string correo, CancellationToken ct = default)
        {
            return await _context.Administradores.FirstOrDefaultAsync(ad => ad.Correo == correo, ct);
        }
    }
}
