using Application.DTOs.Request.HorarioCancha;

namespace Application.DTOs.Request.Cancha
{
    public class ActualizarCanchaRequest
    {
        public string? Nombre { get; set; }
        public int? TipoCanchaId { get; set; }
        public List<ActualizarHorarioCanchaRequest>? horarios { get; set; }
    }
}
