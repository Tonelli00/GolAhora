using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Partidos
{
    public interface IPartidoQuery
    {
        Task<Partido> ObtenerPartidoPorId(int id, CancellationToken ct = default);
        Task<IEnumerable<Partido>> ObtenerPartidoPorEquipo(int equipoId, CancellationToken ct = default);
    }
}
