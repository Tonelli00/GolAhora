
using Application.DTOs.Response.Profesional;

namespace Application.DTOs.Response.Entrenamiento
{
    public class EntrenamientoFullResponse
    {
        public string Nombre { get; set; }
        public int Id_Entrenamiento { get; set; }
        public ProfesionalResponse Profesional{ get; set; }
        public int Cupo {  get; set; }
        public double Precio { get; set; }
    }
}
