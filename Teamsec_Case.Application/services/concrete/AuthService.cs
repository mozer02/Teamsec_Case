using Teamsec_Case.Application.dtos;
using Teamsec_Case.Domain.models;
using Teamsec_Case.Domain.repositories;
using System;
using System.Linq;
using BC = BCrypt.Net.BCrypt;
using Teamsec_Case.Application.services.abstraction;

namespace Teamsec_Case.Application.services.concrete
{
    public class AuthService : IAuthService
    {
        public AuthService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        readonly ITokenService _tokenService;
        readonly IUserRepository _userRepository;
        public UserLoginResponse LoginUser(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }
            var user = _userRepository.GetByEmail(request.Email);

            if (user == default || !BC.Verify(request.Password, user.Password))
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var generatedTokenInformation = _tokenService.GenerateToken(user);

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;


            return response; ;
        }
        public bool UserRegister(UserRegisterRequestDto dto)
        {
            var user = _userRepository.GetQuery(x => x.Email == dto.Email || x.Username == dto.Username).FirstOrDefault();

            if (user != null)
            {
                throw new Exception("Kullanıcı bulunmaktadır");
            }
            var userToBeCreated = new User
            {
                CreateDate = DateTime.Now,
                Email = dto.Email,
                Password = BC.HashPassword(dto.Password),
                Username = dto.Username,
                IsActive = true
            };
            _userRepository.Add(userToBeCreated);
            _userRepository.Save();
            return true;
        }
    }
}
