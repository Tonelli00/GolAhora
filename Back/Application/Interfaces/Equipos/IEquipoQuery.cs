using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.Request.Equipos;
using Application.DTOs.Response.Equipos;

namespace Application.Interfaces.Equipos
{
    public interface IEquipoQuery
    {
        Task<Equipo> ObtenerEquipoPorId(int id, CancellationToken ct = default);
        Task<IEnumerable<Equipo>> ObtenerEquiposPorCompetencia(int competenciaId, CancellationToken ct = default);
        Task<bool> ExisteEquipo(int equipoId, CancellationToken ct = default);
    }

}
