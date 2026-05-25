using Application.DTOs.Request.Profesional;
using Application.DTOs.Response.Profesional;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Profesionales
{
    public interface IProfesionalMapper
    {
        Task<Profesor> MapearProfesorRequestAEntidad(RegistrarProfesorRequest request);
        Task<Entrenador> MapearEntrenadorRequestAEntidad(RegistrarEntrenadorRequest request);
        Task<ProfesorResponse> MapearProfesorEntidadAResponse(Profesor profesor);
        Task<EntrenadorResponse> MapearEntrenadorEntidadAResponse(Entrenador entrenador);
        Task<List<ProfesorResponse>> ObtenerTodosProfesoresResponse(List<Profesor> profesores);
        Task<List<EntrenadorResponse>> ObtenerTodosEntrenadoresResponse(List<Entrenador> entrenadores);
    }
}
