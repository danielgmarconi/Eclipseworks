using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;

namespace Eclipseworks.Application.Interfaces
{
    public interface IUserService
    {
        Task<MethodResponse> Create(UserDTO userDto);
        Task<MethodResponse> Authentication(AuthenticationDTO authenticationDto);
    }
}
