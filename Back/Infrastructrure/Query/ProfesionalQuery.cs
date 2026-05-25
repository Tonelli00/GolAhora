using Application.Interfaces.Profesionales;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class ProfesionalQuery : IProfesionalQuery
    {
        private readonly AppDbContext context;

        public ProfesionalQuery(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Profesor> ObtenerProfesorPorId(int id)
        {
            return await context.Set<Profesor>()
                .Include(p => p.Clases)
                .FirstOrDefaultAsync(p => p.Dni == id);
        }

        public async Task<Entrenador> ObtenerEntrenadorPorId(int id)
        {
            return await context.Set<Entrenador>()
                .Include(e => e.Entrenamientos)
                .FirstOrDefaultAsync(e => e.Dni == id);
        }

        public async Task<List<Profesor>> ObtenerTodosLosProfesores()
        {
            return await context.Set<Profesor>()
                .Include(p => p.Clases)
                .ToListAsync();
        }

        public async Task<List<Entrenador>> ObtenerTodosLosEntrenadores()
        {
            return await context.Set<Entrenador>()
                .Include(e => e.Entrenamientos)
                .ToListAsync();
        }
    }
}
