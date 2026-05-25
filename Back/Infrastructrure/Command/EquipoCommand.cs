using Application.Interfaces.Equipos;
using Domain.Entities;
using Infrastructure.Persistence;


namespace Infrastructure.Command
{
    public class EquipoCommand: IEquipoCommand
    {
        private readonly AppDbContext _context;
        public EquipoCommand(AppDbContext context) { 
            _context = context;
        }
        public async Task<int> CrearEquipo(Equipo equipo, CancellationToken ct = default)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync(ct);
            return equipo.IdEquipo;
        }
        public async Task ModificarEquipo(Equipo equipo, CancellationToken ct = default)
        {
            _context.Equipos.Update(equipo);
            await _context.SaveChangesAsync(ct);
        }
        public async Task EliminarEquipo(Equipo equipo, CancellationToken ct = default)
            {
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync(ct);
        }
    }

}


