
namespace Application.DTOs.Response.Reserva
{
    public class ReservaEliminadaResponse
    {
        public bool TienePenalizacion {  get; set; }
        public double? MontoPenalizacion {get; set; }
        public ReservaResponse Reserva {  get; set; }
    }
}
