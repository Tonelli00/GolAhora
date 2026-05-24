using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Profesional
{
    public class ProfesionalResponse : UsuarioResponse
    {
        public string Certificado { get; set; }
        public bool EstaCertificado { get; set; }
    }
}
