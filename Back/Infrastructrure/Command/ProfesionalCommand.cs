using Application.Interfaces.Profesionales;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class ProfesionalCommand : IProfesionalCommand
    {
        private readonly AppDbContext context;

        public ProfesionalCommand(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Profesor> RegistrarProfesor(Profesor profesor)
        {
            await context.Set<Profesor>().AddAsync(profesor);
            await context.SaveChangesAsync();
            return profesor;
        }

        public async Task<Entrenador> RegistrarEntrenador(Entrenador entrenador)
        {
            await context.Set<Entrenador>().AddAsync(entrenador);
            await context.SaveChangesAsync();
            return entrenador;
        }

        public async Task<Profesor> ModificarProfesor(Profesor profesor)
        {
            context.Set<Profesor>().Update(profesor);
            await context.SaveChangesAsync();
            return profesor;
        }

        public async Task<Entrenador> ModificarEntrenador(Entrenador entrenador)
        {
            context.Set<Entrenador>().Update(entrenador);
            await context.SaveChangesAsync();
            return entrenador;
        }

        public async Task<bool> EliminarProfesional(int id)
        {
            var profesor = await context.Set<Profesor>().FirstOrDefaultAsync(p => p.Dni == id);
            if (profesor != null)
            {
                context.Set<Profesor>().Remove(profesor);
                return await context.SaveChangesAsync() > 0;
            }

            var entrenador = await context.Set<Entrenador>().FirstOrDefaultAsync(e => e.Dni == id);
            if (entrenador != null)
            {
                context.Set<Entrenador>().Remove(entrenador);
                return await context.SaveChangesAsync() > 0;
            }

            return false; 
        }

        public async Task<Profesor> VerificarCertificacionProfesor(int id, bool estado)
        {
            var profesor = await context.Set<Profesor>().FirstOrDefaultAsync(p => p.Dni == id);
            if (profesor != null)
            {
                profesor.EstaCertificado = estado;
                context.Set<Profesor>().Update(profesor);
                await context.SaveChangesAsync();
            }
            return profesor;
        }

        public async Task<Entrenador> VerificarCertificacionEntrenador(int id, bool estado)
        {
            var entrenador = await context.Set<Entrenador>().FirstOrDefaultAsync(e => e.Dni == id);
            if (entrenador != null)
            {
                entrenador.EstaCertificado = estado;
                context.Set<Entrenador>().Update(entrenador);
                await context.SaveChangesAsync();
            }
            return entrenador;
        }

        public async Task<bool> InsertarClase(Clase clase)
        {
            await context.Set<Clase>().AddAsync(clase);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertarEntrenamiento(Entrenamiento entrenamiento)
        {
            await context.Set<Entrenamiento>().AddAsync(entrenamiento);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
