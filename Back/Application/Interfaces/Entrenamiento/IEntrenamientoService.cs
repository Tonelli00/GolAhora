using Application.DTOs.Request.Entrenamiento;
using Application.DTOs.Response.Entrenamiento;
using Application.DTOs.Response.Inscripcion;

namespace Application.Interfaces.Entrenamiento
{
     public interface IEntrenamientoService
    {
        Task<EntrenamientoResponse> ModificarEntrenamiento(int entrenamientoId, ModificarEntrenamientoRequest request);
        
        Task<EntrenamientoResponse> ImprimirEntrenamiento(int entrenamientoId);

        Task<EntrenamientoResponse> ConsultarEntrenamiento(int entrenamientoId);

        Task<EntrenamientoResponse> ProgramarEntrenamiento(ProgramarEntrenamientoRequest request);

        Task<EntrenamientoResponse> EliminarEntrenamiento(int entrenamientoId);
        Task<List<EntrenamientoFullResponse>> ListarEntrenamientos();
        Task<List<EntrenamientoResponse>> ListarEntrenamientosPorDni(int entrenadorDni);
        Task<List<InscripcionResponse>> VerInscriptos(int entrenamientoId);
      

    }
}
