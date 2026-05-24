using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Profesional
{
    public class RegistrarEntrenadorRequest : RegistrarUsuarioRequest
    {
        public string Certificado { get; set; }
    }
}
