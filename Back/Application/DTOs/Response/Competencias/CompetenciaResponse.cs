using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTOs.Response.Competencias
{

    public class CompetenciaResponse
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cupos { get; set; }
        public double Precio { get; set; }
    }
}
