using Hotels.API.Models.Users;

namespace Hotels.API.Contracts
{
    public interface IAuthManager
    {
        Task<AuthResponseDTO> Login(LoginDTO loginDto);
    }
}
