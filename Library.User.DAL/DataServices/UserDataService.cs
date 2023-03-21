using Library.User.DAL.Models;
using Library.User.DAL.Repository;

namespace Library.User.DAL.DataServices
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;

        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> AddNewUserAsync(UserModel user)
        {
            try
            {
                return await _userRepository.AddUserAsync(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserModel> GetUserByIdAsync(Guid userId)
        {
            try
            {
                return await _userRepository.GetUserByIdAsync(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> LoginUserAsync(UserModel userToLogin)
        {
            try
            {
                return await _userRepository.LoginUserAsync(userToLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            try
            {
                return await _userRepository.GetUsersAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            try
            {
                await _userRepository.DeleteUserAsync(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
