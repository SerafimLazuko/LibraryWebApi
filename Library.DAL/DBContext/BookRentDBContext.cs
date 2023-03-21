using Library.DAL.Models;
using Library.DAL.TestDataDbInitializer;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.DBContext
{
    public class BookRentDBContext : DbContext
    {
        public DbSet<BookModel> BookModels { get; set; }

        public DbSet<RentModel> RentModels { get; set; }

        public BookRentDBContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookModel>().HasKey(x => x.BookId);
            builder.Entity<RentModel>().HasKey(x => x.RentId);

            builder.Entity<RentModel>().HasOne(r => r.BookModel).WithMany(b => b.Rents).HasForeignKey(r => r.BookId);

            builder.Entity<BookModel>().ToTable("Books");
            builder.Entity<RentModel>().ToTable("Rents");

            //fills db with an initial data on a creation
            new DbInitializer(builder).Seed();
        }
    }
}
