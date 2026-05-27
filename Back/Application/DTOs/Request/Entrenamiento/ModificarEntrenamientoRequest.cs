

namespace Application.DTOs.Request.Entrenamiento
{
    public class ModificarEntrenamientoRequest
    {
        public string? Nombre { get; set; }
        public int? Dni_Entrenador { get; set; }
        public double? Precio { get; set; }
    }
}
