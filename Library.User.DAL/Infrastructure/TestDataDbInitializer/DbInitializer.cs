using Library.User.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.User.DAL.TestDataDbInitializer
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var user1 = new UserModel
            {
                UserId = new Guid("da82b1c7-a60c-4590-9d3d-65e4e47edcef"),
                Login = "SamKing",
                Password = "secret",
                Name = "Sam",
                Surname = "King"
            };

            _modelBuilder.Entity<UserModel>(u => u.HasData(user1));
        }
    }
}
