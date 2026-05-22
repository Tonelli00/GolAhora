
namespace Domain.Entities
{
    public class Entrenador:Profesional 
    {
        public IEnumerable<Entrenamiento> Entrenamientos { get; set; }
    }
}
