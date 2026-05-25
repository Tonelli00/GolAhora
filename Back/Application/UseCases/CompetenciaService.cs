using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Request.Competencias;
using Application.DTOs.Response.Competencias;
using Application.DTOs.Response.Equipos;
using Application.DTOs.Response.Partidos;
using Application.Interfaces.Competencias;
using Domain.Entities;

namespace Application.UseCases
{
    public class CompetenciaService : ICompetenciaService
    {
        private readonly ICompetenciaCommand _competenciaCommand;
        private readonly ICompetenciaQuery _competenciaQuery;
        public CompetenciaService(ICompetenciaCommand competenciaCommand, ICompetenciaQuery competenciaQuery)
        {
            _competenciaCommand = competenciaCommand;
            _competenciaQuery = competenciaQuery;
        }

        public async Task<int> CrearCompetencia(CrearCompetenciaRequest request, CancellationToken ct = default)
        {
            Competencia competencia = request.tipo switch
            {
                "Liga" => new Liga(),
                "Torneo" => new Torneo(),
                _ => throw new ArgumentException("Formato invalido")
            };

            competencia.Nombre = request.nombre;
            competencia.Descripcion = request.descripcion;
            competencia.Cupos = request.cupos;
            competencia.Precio = request.precio;

            return await _competenciaCommand.CrearCompetencia(competencia, ct);

        }

        public async Task ModificarCompetencia(ModificarCompetenciaRequest request, CancellationToken ct = default)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(request.id, ct)
                ?? throw new KeyNotFoundException($"No se encontro competencias con id: {request.id}");

            competencia.Nombre = request.nombre ?? competencia.Nombre;
            competencia.Descripcion = request.descripcion ?? competencia.Descripcion;
            competencia.Cupos = request.cupos != 0 ? request.cupos : competencia.Cupos;
            competencia.Precio = request.precio != 0 ? request.precio : competencia.Precio;

            await _competenciaCommand.ModificarCompetencia(competencia, ct);
        }

        public async Task<CompetenciaResponse?> ObtenerCompetenciaPorId(int id, CancellationToken ct = default)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(id, ct);
            if (competencia is null) return null;

            return new CompetenciaResponse
            {
                Nombre = competencia.Nombre,
                Cupos = competencia.Cupos,
                Descripcion = competencia.Descripcion,
                Precio = competencia.Precio
            };
        }

        public async Task EliminarCompetencia(int idCompetencia, CancellationToken ct = default)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(idCompetencia, ct)
                ?? throw new KeyNotFoundException($"No se encontro competencias con id: {idCompetencia}");

            await _competenciaCommand.EliminarCompetencia(competencia, ct);
        }

        public async Task<int> AgregarEquipo(AgregarEquipoRequest request,int idCompetencia, CancellationToken ct = default)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(idCompetencia, ct)
                 ?? throw new KeyNotFoundException($"No se encontro competencias con id: {idCompetencia}");

            if (competencia.Equipos.Count >= competencia.Cupos)
            {
                throw new InvalidOperationException($"Cupo maximo alcanzado en la competencia {competencia.Nombre}");
            }

            if (competencia.Equipos.Any(e => e.Nombre == request.nombre))
            {
                throw new InvalidOperationException($"Ya existe un equipo con el nombre {request.nombre}");
            }

            var equipo = new Equipo
            {
                Nombre = request.nombre
            };

            await _competenciaCommand.AgregarEquipo(equipo, idCompetencia, ct);
            return equipo.IdEquipo;
        }

        public async Task<IEnumerable<CompetenciaResponse?>> ObtenerTodasLasCompetencias(CancellationToken ct = default)
        {
            var lista = await _competenciaQuery.ObtenerTodasLasCompetencias(ct);
            if (lista is null) return null;

            return lista.Select(c => new CompetenciaResponse
            {
                Nombre = c.Nombre,
                Cupos = c.Cupos,
                Descripcion = c.Descripcion,
                Precio = c.Precio
            });
        }

        public async Task<IEnumerable<EquipoResponse?>> ObtenerEquipos(int idcompetencia, CancellationToken ct = default)
        {
            var equipos = await _competenciaQuery.ObtenerEquipos(idcompetencia, ct);
            return equipos.Select(e => new EquipoResponse
            {
                id = e.IdEquipo,
                nombre = e.Nombre,
                derrotas = e.Derrotas,
                victorias = e.Victorias

            });
        }
        public async Task<IEnumerable<PartidoResponseCompetencia?>> ObtenerPartidos(int idcompetencia, CancellationToken ct = default)
        {
            var partidos = await _competenciaQuery.ObtenerPartidos(idcompetencia, ct);
            return partidos.Select(p => new PartidoResponseCompetencia
            {
                resultado = p.Resultado,
                horaInicio = p.HoraInicio,
                horaFin = p.HoraFin,
                EquipoLocal = p.EquipoLocal.Nombre,
                EquipoVis = p.EquipoVis.Nombre
            });
        }
        public async Task<bool> CompetenciaExiste(int idcompetencia, CancellationToken ct = default)
        {
            return await _competenciaQuery.CompetenciaExiste(idcompetencia, ct);
        }
    }
}



