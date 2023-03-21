using Library.DAL.Models;

namespace Library.DAL.DataServices
{
    public interface IBookRentDataService
    {
        Task<Guid> AddNewBookAsync(BookModel book);
        Task CloseBookRentAsync(RentModel rent);
        Task<Guid> CreateBookRentAsync(RentModel rent);
        Task<IEnumerable<RentModel>> GetAllUserRentsByUserIdAsync(Guid userId);
        Task DeleteBookAsync(Guid bookId);
        Task<Guid> EditBookInfoAsync(BookModel book);
        Task<IEnumerable<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIBANAsync(string bookIban);
        Task<BookModel> GetBookByIdAsync(Guid bookId);
    }
}