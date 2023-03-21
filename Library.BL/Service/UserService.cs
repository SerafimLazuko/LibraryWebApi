using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Infrastructure;
using Library.User.DAL.Models;
using Library.User.DAL.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Library.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return mapper.Map<IEnumerable<UserDTO>>(await userRepository.GetUsersAsync());
        }

        public async Task<Guid> RegisterUserAsync(UserToRegisterDTO userToRegisterDTO)
        {
            try
            {
                var userId = Guid.NewGuid();

                var userModel = mapper.Map<UserModel>(userToRegisterDTO);
                userModel.UserId = userId;

                return await userRepository.AddUserAsync(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserLoginedDTO> LoginUserAsync(UserToLoginDTO userToLoginDTO)
        {
            try
            {
                var userModel = mapper.Map<UserModel>(userToLoginDTO);

                var result = await userRepository.LoginUserAsync(userModel);

                var userDTO = mapper.Map<UserLoginedDTO>(await userRepository.GetUserByIdAsync(result));

                userDTO.Token = GenerateToken(userDTO.Name);

                return userDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GenerateToken(string name)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
