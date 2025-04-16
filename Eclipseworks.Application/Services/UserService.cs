using AutoMapper;
using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Application.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IEncryptionService _encryptionService;
    public UserService(IUserRepository userRepository, IMapper mapper, IJwtService jwtService, IEncryptionService encryptionService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtService = jwtService;
        _encryptionService = encryptionService;
    }
    public async Task<MethodResponse> Create(UserDTO userDto)
    {
        var result = new MethodResponse();
        try
        {
            //if (await _userRepository.Get(userDto.Email) != null)
            DomainExceptionValidation.When(await _userRepository.Get(userDto.Email) != null, "Email already exists.");
            var userEntity = _mapper.Map<User>(userDto);
            userEntity.PasswordUpdate(_encryptionService.Encrypt(userEntity.Password));
            userEntity.DateCreated = DateTime.Now;
            await _userRepository.Create(userEntity);
            userEntity.PasswordUpdate("");
            result.Success = true;
            result.StatusCode = 201;
            result.Response = _mapper.Map<UserDTO>(userEntity);
        }
        catch (Exception e)
        {
            result.StatusCode = 500;
            result.Message = e.Message;
        }
        return result;
    }
}
