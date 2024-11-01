using Backend.Domain.Entities;

namespace Backend.Application.Interfaces
{
    public interface ITareaRepository
    {
        Task<Tarea> GetByIdAsync(int id);
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task AddAsync(Tarea tarea);
        Task UpdateAsync(int id, Tarea tarea);
        Task DeleteAsync(int id);
    }
}
