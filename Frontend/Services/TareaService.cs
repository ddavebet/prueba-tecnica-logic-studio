using Frontend.DTOs;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class TareaService
    {
        private readonly HttpClient _httpClient;

        public TareaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TareaDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TareaDto>>("tareas");
        }

        public async Task<TareaDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TareaDto>($"tareas/{id}");
        }

        public async Task AddAsync(TareaDto tarea)
        {
            await _httpClient.PostAsJsonAsync("tareas", tarea);
        }

        public async Task UpdateAsync(TareaDto tarea)
        {
            await _httpClient.PutAsJsonAsync($"tareas/{tarea.Id}", tarea);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"tareas/{id}");
        }
    }
}
