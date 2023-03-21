using Library.DAL.DBContext;
using Library.DAL.Infrastructure.CustomExceptions;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository
{
    internal class MSSQLBookRentRepository : IBookRentRepository
    {
        private readonly BookRentDBContext bookRentDBContext;

        public MSSQLBookRentRepository(BookRentDBContext _bookRentDBContext)
        {
            bookRentDBContext = _bookRentDBContext;
        }

        public async Task<BookModel> GetBookByIdAsync(Guid bookId)
        {
            try
            {
                var result =  await bookRentDBContext.BookModels.Include(b => b.Rents).Where(x => x.BookId == bookId).FirstOrDefaultAsync();

                if (result == null)
                    throw new BookNotFoundException($"Book with such ID - {bookId} has not been found.");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BookModel> GetBookByIBANAsync(string bookIban)
        {
            try
            {
                var result = await bookRentDBContext.BookModels.Include(b => b.Rents).Where(x => x.IBAN == bookIban).FirstOrDefaultAsync();

                if (result == null)
                    throw new BookNotFoundException($"Book with such IBAN - {bookIban} has not been found.");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            try
            {
                return bookRentDBContext.BookModels;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<Guid> AddNewBookAsync(BookModel book)
        {
            try
            {
                await bookRentDBContext.BookModels.AddAsync(book);
                await bookRentDBContext.SaveChangesAsync();
                
                return book.BookId;
            }
            catch (Exception e)
            {
                //e.Message = $"book has not been added. Id - {book.BookId}";
                throw;
            }
        }

        public async Task<Guid> EditBookInfoAsync(BookModel book)
        {
            try
            {
                var bookToUpdate = bookRentDBContext.BookModels.FirstOrDefault(b => b.BookId == book.BookId);

                if (bookToUpdate != null)
                {
                    bookRentDBContext.Entry(bookToUpdate).State = EntityState.Modified;
                    bookToUpdate.EditBook(book);
                    await bookRentDBContext.SaveChangesAsync();
                }
                else
                {
                    throw new BookNotFoundException($"Book with such ID - {book.BookId} has not been found.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return book.BookId;
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            try
            {
                var bookToDelete = bookRentDBContext.BookModels.FirstOrDefault(b => b.BookId == bookId);

                if (bookToDelete != null)
                    bookRentDBContext.BookModels.Remove(bookToDelete);
                else
                    throw new BookNotFoundException($"Book with such ID - {bookId} has not been found.");

                await bookRentDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> CreateBookRentAsync(RentModel rent)
        {
            try
            {
                await bookRentDBContext.RentModels.AddAsync(rent);
                await bookRentDBContext.SaveChangesAsync();
                
                return rent.RentId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RentModel>> GetAllUserRentsByUserIdAsync(Guid userId)
        {
            try
            {
                return await bookRentDBContext.RentModels.Where(r => r.UserId == userId).Include(r => r.BookModel).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CloseBookRentAsync(RentModel rent)
        {
            try
            {
                var rentToClose = bookRentDBContext.RentModels.FirstOrDefault(b => b.RentId == rent.RentId);
                
                if(rentToClose != null)
                {
                    rentToClose.RentClosed = rent.RentClosed;
                    await bookRentDBContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Rent with such id has not been found: {rent.RentId}");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
