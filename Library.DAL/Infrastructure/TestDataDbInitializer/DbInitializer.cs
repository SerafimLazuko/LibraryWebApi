using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.TestDataDbInitializer
{
    internal class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var book1 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban1",
                Name = "NAME1",
                Description = "desc1",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book2 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban2",
                Name = "NAME2",
                Description = "desc2",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book3 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban3",
                Name = "NAME3",
                Description = "desc3",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book4 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban4",
                Name = "NAME4",
                Description = "desc4",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book5 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban5",
                Name = "NAME5",
                Description = "desc5",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book6 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban6",
                Name = "NAME6",
                Description = "desc6",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book7 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban7",
                Name = "NAME7",
                Description = "desc7",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book8 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban8",
                Name = "NAME8",
                Description = "desc8",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book9 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban9",
                Name = "NAME9",
                Description = "desc9",
                Author = "AAA",
                Genre = "fantastic"
            };
            var book10 = new BookModel
            {
                BookId = Guid.NewGuid(),
                IBAN = "iban10",
                Name = "NAME10",
                Description = "desc10",
                Author = "AAA",
                Genre = "fantastic"
            };

            var rent1 = new RentModel
            {
                BookId = book1.BookId,
                UserId = new Guid("da82b1c7-a60c-4590-9d3d-65e4e47edcef"),
                RentStarted = DateTime.UtcNow,
                RentId = Guid.NewGuid()
            };
            var rent2 = new RentModel
            {
                BookId = book2.BookId,
                UserId = new Guid("da82b1c7-a60c-4590-9d3d-65e4e47edcef"),
                RentStarted = DateTime.UtcNow,
                RentId = Guid.NewGuid()
            };


            _modelBuilder.Entity<BookModel>(b =>
            {
                b.HasData(book1);
                b.HasData(book2);
                b.HasData(book3);
                b.HasData(book4);
                b.HasData(book5);
                b.HasData(book6);
                b.HasData(book7);
                b.HasData(book8);
                b.HasData(book9);
                b.HasData(book10);
            });
            _modelBuilder.Entity<RentModel>(r => r.HasData(rent1));
        }
    }
}   
