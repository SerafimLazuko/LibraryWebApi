using Library.User.DAL.Models;

namespace Library.User.DAL.Repository
{
    public interface IUserRepository
    {
        Task<Guid> AddUserAsync(UserModel user);
        Task DeleteUserAsync(Guid userId);
        Task<UserModel> GetUserByIdAsync(Guid userId);
        Task<Guid> LoginUserAsync(UserModel userToLogin);
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}