using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Response.Partidos;
using Application.DTOs.Request.Partidos;
using Domain.Entities;


namespace Application.Interfaces.Partidos
{
    public interface IPartidoService
    {
        Task<int> CrearPartido(AgregarPartidoRequest partido, CancellationToken ct = default);
        Task ModificarPartido(ModificarPartidoRequest partido, CancellationToken ct = default);
        Task EliminarPartido(int idPartido, CancellationToken ct = default);
        Task<PartidoResponse> ObtenerPartidoPorId(int id, CancellationToken ct = default);
        Task<IEnumerable<PartidoResponse>> ObtenerPartidoPorEquipo(int equipoId, CancellationToken ct = default);
    }
}