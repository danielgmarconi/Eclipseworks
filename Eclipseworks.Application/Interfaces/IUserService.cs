using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;

namespace Eclipseworks.Application.Interfaces
{
    public interface IUserService
    {
        Task<MethodResponse> GetUsers();
        Task<MethodResponse> GetById(int id);
        Task<MethodResponse> GetByEmail(string Email);
        Task<MethodResponse> Create(UserDTO userDto);
        Task<MethodResponse> Authentication(AuthenticationDTO authenticationDto);
        Task<MethodResponse> Update(UserDTO userDto);
        Task<MethodResponse> Remove(int id);
    }
}
