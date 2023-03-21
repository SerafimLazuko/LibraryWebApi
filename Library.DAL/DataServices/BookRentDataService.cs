using Library.DAL.Models;
using Library.DAL.Repository;

namespace Library.DAL.DataServices
{
    public class BookRentDataService : IBookRentDataService
    {
        private IBookRentRepository BookRentReposytory { get; set; }

        public BookRentDataService(IBookRentRepository _bookRentReposytory)
        {
            BookRentReposytory = _bookRentReposytory;
        }

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            try
            {
                return await BookRentReposytory.GetAllBooksAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BookModel> GetBookByIdAsync(Guid bookId)
        {
            try
            {
                return await BookRentReposytory.GetBookByIdAsync(bookId);
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
                return await BookRentReposytory.GetBookByIBANAsync(bookIban);
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
                return await BookRentReposytory.AddNewBookAsync(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> EditBookInfoAsync(BookModel book)
        {
            try
            {
                return await BookRentReposytory.EditBookInfoAsync(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBookAsync(Guid bookId)
        {
            try
            {
                await BookRentReposytory.DeleteBookAsync(bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RentModel>> GetAllUserRentsByUserIdAsync(Guid userId)
        {
            var result = await BookRentReposytory.GetAllUserRentsByUserIdAsync(userId);
            return result;
        }

        public async Task<Guid> CreateBookRentAsync(RentModel rent)
        {
            try
            {
                return await BookRentReposytory.CreateBookRentAsync(rent);
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
                await BookRentReposytory.CloseBookRentAsync(rent);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}