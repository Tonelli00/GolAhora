
using Application.Interfaces.Administrador;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class AdministradorCommand : IAdministradorCommand
    {
        private readonly AppDbContext _context;

        public AdministradorCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Administrador> CrearAdministrador(Administrador Administrador, CancellationToken ct = default)
        {
            await _context.Administradores.AddAsync(Administrador, ct);
            await _context.SaveChangesAsync();
            return Administrador;
        }
    }
}
