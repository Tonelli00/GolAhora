using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Competencias
{

    public class CrearCompetenciaRequest
    {
        public string tipo {  get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cupos { get; set; }
        public double precio { get; set; }
    }
}