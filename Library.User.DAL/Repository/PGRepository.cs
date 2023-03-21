using Library.User.DAL.Infrastructure.CustomExceptions;
using Library.User.DAL.Models;
using Library.User.DAL.UsersDbContext;
using Microsoft.EntityFrameworkCore;

namespace Library.User.DAL.Repository
{
    public class PGRepository : IUserRepository
    {
        private readonly UserDBContext dbContext;
        public PGRepository(UserDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Guid> AddUserAsync(UserModel user)
        {
            try
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();

                return user.UserId;
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
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

                if (user == null)
                {
                    throw new UserNotFoundException($"User with ID {userId} has not been found.");
                }

                return user;
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
                var user = await dbContext.Users.FindAsync(userToLogin.Login, userToLogin.Password);

                if(user == null)
                {
                    throw new UserNotFoundException($"User has not been found.");
                }

                return user.UserId;
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
                return dbContext.Users;
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
                var userToDelete = await dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

                if (userToDelete != null)
                {
                    dbContext.Users.Remove(userToDelete);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new UserNotFoundException($"User with ID {userId} has not been found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
