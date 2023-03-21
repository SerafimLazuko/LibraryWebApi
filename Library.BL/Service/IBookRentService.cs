using Library.BLL.DTO;

namespace Library.BLL.Service
{
    public interface IBookRentService
    {
        Task<string> AddNewBookAsync(BookToAddDTO book);
        Task DeleteBookAsync(string bookId);
        Task<string> EditBookInfoAsync(BookToEditDTO bookToEditDTO);
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIBANAsync(string bookIban);
        Task<BookDTO> GetBookByIdAsync(string bookId);
        Task<IEnumerable<RentDTO>> GetAllUserRentsByUserIdAsync(string userId);
        Task CloseBookRentAsync(RentToCloseDTO rentToClose);
        Task<Guid> CreateBookRentAsync(RentToCreateDTO rent);
    }
}