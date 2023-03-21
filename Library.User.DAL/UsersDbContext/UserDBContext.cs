using Library.User.DAL.Models;
using Library.User.DAL.TestDataDbInitializer;
using Microsoft.EntityFrameworkCore;

namespace Library.User.DAL.UsersDbContext
{
    public class UserDBContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>().HasKey(u => u.UserId).HasName("UserIdKey");
            builder.Entity<UserModel>().HasKey(u => new { u.Login, u.Password }).HasName("LoginPasswordKey");
            builder.Entity<UserModel>().ToTable("Users");

            new DbInitializer(builder).Seed();
        }
    }
}
