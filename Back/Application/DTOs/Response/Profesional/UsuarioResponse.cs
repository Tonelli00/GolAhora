using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Profesional
{
    //Mismo caso de UsuarioRequest que se hereda en RegistrarProfesorRequest y RegistrarEntrenadorRequest, pero para el response, ya que ambos tipos de profesionales comparten la misma información a mostrar
    //Se borrara si hay otro y se debera poner el otro para que lo herede  
    public class UsuarioResponse
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}
