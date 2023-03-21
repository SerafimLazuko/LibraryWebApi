using Library.User.DAL.Models;

namespace Library.User.DAL.DataServices
{
    public interface IUserDataService
    {
        Task<Guid> AddNewUserAsync(UserModel user);
        Task DeleteUserAsync(Guid userId);
        Task<UserModel> GetUserByIdAsync(Guid userId);
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}