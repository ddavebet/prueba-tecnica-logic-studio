using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly ApplicationDbContext _context;

        public TareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tarea> GetByIdAsync(int id)
        {
            var tarea = await _context.Tareas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (tarea == null)
            {
                throw new Exception("Tarea no encontrada.");
            }
            return tarea;
        }

        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            var tareas = await _context.Tareas.OrderBy(x => x.FechaCreacion).ToListAsync();

            return tareas;
        }

        public async Task AddAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Tarea tarea)
        {
            var tareaEnDb = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);
            if (tareaEnDb == null)
            {
                throw new Exception("La tarea seleccionada no existe.");
            }

            tareaEnDb.Titulo = tarea.Titulo;
            tareaEnDb.Descripcion = tarea.Descripcion;
            tareaEnDb.FechaCreacion = tarea.FechaCreacion;
            tareaEnDb.FechaVencimiento = tarea.FechaVencimiento;
            tareaEnDb.Completada = tarea.Completada;

            _context.Update(tareaEnDb);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);

            if (tarea == null)
            {
                throw new Exception("La tarea seleccionada no existe.");
            }

            _context.Remove(tarea);
            await _context.SaveChangesAsync();
        }
    }
}
