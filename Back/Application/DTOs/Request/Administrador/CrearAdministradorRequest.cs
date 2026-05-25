
namespace Application.DTOs.Request.Administrador
{
    public class CrearAdministradorRequest
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateOnly FechaNac { get; set; }
    }
}
