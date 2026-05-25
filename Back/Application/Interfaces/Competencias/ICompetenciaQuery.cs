using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs.Request.Competencias;
using Application.DTOs.Response.Competencias;


namespace Application.Interfaces.Competencias
{
    public interface ICompetenciaQuery
    {
        Task<Competencia> ObtenerCompetenciaPorId(int id, CancellationToken ct = default);
        Task<IEnumerable<Competencia>> ObtenerTodasLasCompetencias(CancellationToken ct = default);
        Task<IEnumerable<Equipo>> ObtenerEquipos(int id, CancellationToken ct = default);
        Task<IEnumerable<Partido>> ObtenerPartidos(int id, CancellationToken ct = default);
        Task<bool> CompetenciaExiste(int idcompetencia, CancellationToken ct = default);
    }
}
