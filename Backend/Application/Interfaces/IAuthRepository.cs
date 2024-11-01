using Backend.Application.DTOs.Request;

namespace Backend.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
