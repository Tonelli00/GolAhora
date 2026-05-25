using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Partidos;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class PartidoQuery : IPartidoQuery
    {
        private readonly AppDbContext _context;
        public PartidoQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Partido> ObtenerPartidoPorId(int id, CancellationToken ct = default)
        {
            return await _context.Partidos.AsNoTracking().FirstOrDefaultAsync(p => p.IdPartido == id, ct);
        }
        public async Task<IEnumerable<Partido>> ObtenerPartidoPorEquipo(int equipoId, CancellationToken ct = default)
        {
            return await _context.Partidos.AsNoTracking().Where(p => p.IdEquipoLocal == equipoId ||
                            p.IdEquipoVis == equipoId)
                .ToListAsync(ct);
        }
    }
}


