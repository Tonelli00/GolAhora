using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Profesional
{
    //DTO creado para que profesores y entrenadores puedan heredar de este y no repetir código. Se borrara si ya se creo otro DTO, si eso pasa se debe cambiar en profesor y entrenador para que hereden de ese DTO y no de este.
    public class RegistrarUsuarioRequest 
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaNac { get; set; }
    }
}
