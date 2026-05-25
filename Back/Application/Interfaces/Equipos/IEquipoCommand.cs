using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.Request.Equipos;
using Application.DTOs.Response.Equipos;

namespace Application.Interfaces.Equipos
{
    public interface IEquipoCommand
    {
        Task<int> CrearEquipo (Equipo equipo, CancellationToken ct = default);
        Task ModificarEquipo(Equipo equipo, CancellationToken ct = default);
        Task EliminarEquipo(Equipo equipo, CancellationToken ct = default);
    }

}

