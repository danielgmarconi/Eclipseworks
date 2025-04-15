using Eclipseworks.Application.DTOs;

namespace Eclipseworks.Application.Interfaces
{
    public interface IUserService
    {
        Task Create(UserDTO userDto);
    }
}
