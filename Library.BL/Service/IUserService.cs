using Library.BLL.DTO;

namespace Library.BLL.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserLoginedDTO> LoginUserAsync(UserToLoginDTO userToLoginDTO);
        Task<Guid> RegisterUserAsync(UserToRegisterDTO userToRegisterDTO);
    }
}