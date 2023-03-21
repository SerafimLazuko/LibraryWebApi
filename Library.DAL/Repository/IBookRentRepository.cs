using Library.DAL.Models;

namespace Library.DAL.Repository
{
    public interface IBookRentRepository
    {
        public Task<IEnumerable<BookModel>> GetAllBooksAsync();

        public Task<BookModel> GetBookByIdAsync(Guid bookId);

        public Task<BookModel> GetBookByIBANAsync(string bookIban);

        public Task<Guid> AddNewBookAsync(BookModel book);

        public Task<Guid> EditBookInfoAsync(BookModel book);

        public Task DeleteBookAsync(Guid bookId);

        public Task<IEnumerable<RentModel>> GetAllUserRentsByUserIdAsync(Guid userId);

        public Task<Guid> CreateBookRentAsync(RentModel rent);

        public Task CloseBookRentAsync(RentModel rent);
    }
}
