using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;

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
    public async Task Create(UserDTO userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);

        //userEntity.PasswordUpdate(_encryptionService.Encrypt(userEntity.Password));
        //var x = _jwtService.GenerateToken(1, "a@a.com");
        //var xxx = _encryptionService.Encrypt("teste");
        //var x1 = _encryptionService.Valid(xxx, "teste1");
        await _userRepository.Create(userEntity);
    }
}
