using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Profesionales
{
    public interface IProfesionalCommand
    {
        Task<Profesor> RegistrarProfesor(Profesor profesor);
        Task<Entrenador> RegistrarEntrenador(Entrenador entrenador);
        Task<Profesor> ModificarProfesor(Profesor profesor);
        Task<Entrenador> ModificarEntrenador(Entrenador entrenador);
        Task<bool> EliminarProfesional(int id);
        Task<Profesor> VerificarCertificacionProfesor(int id, bool estado);
        Task<Entrenador> VerificarCertificacionEntrenador(int id, bool estado);
        Task<bool> InsertarClase(Clase clase);
        Task<bool> InsertarEntrenamiento(Domain.Entities.Entrenamiento entrenamiento);  //Se uso la ruta para no cambiar el namespace de Entrenamiento ya establecido

    }
}
