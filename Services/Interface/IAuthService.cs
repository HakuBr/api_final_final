using APIsprint.DTOs.AuthDTOs;

namespace APIsprint.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO dto);
    }
}