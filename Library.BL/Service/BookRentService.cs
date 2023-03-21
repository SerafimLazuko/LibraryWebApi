using AutoMapper;
using Library.BLL.DTO;
using Library.DAL.DataServices;
using Library.DAL.Models;

namespace Library.BLL.Service
{
    public class BookRentService : IBookRentService
    {
        private readonly IBookRentDataService dataService;
        private readonly IMapper mapper;

        public BookRentService(IBookRentDataService _bookRentDataService, IMapper _mapper)
        {
            dataService = _bookRentDataService;
            mapper = _mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<BookDTO>>(await dataService.GetAllBooksAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BookDTO> GetBookByIdAsync(string bookId)
        {
            try
            {
                return mapper.Map<BookDTO>(await dataService.GetBookByIdAsync(new Guid(bookId)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BookDTO> GetBookByIBANAsync(string bookIban)
        {
            try
            {
                var book = await dataService.GetBookByIBANAsync(bookIban);
                return mapper.Map<BookDTO>(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> AddNewBookAsync(BookToAddDTO bookToAddDTO)
        {
            try
            {
                var bookDTO = mapper.Map<BookDTO>(bookToAddDTO);

                var result = await dataService.AddNewBookAsync(mapper.Map<BookModel>(bookDTO));
                
                if (result != Guid.Empty)
                    return result.ToString();
                else
                    throw new InvalidOperationException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> EditBookInfoAsync(BookToEditDTO bookToEditDTO)
        {
            try
            {
                var bookDTO = mapper.Map<BookDTO>(bookToEditDTO);
                
                var result = await dataService.EditBookInfoAsync(mapper.Map<BookModel>(bookDTO));

                if (result != Guid.Empty)
                    return result.ToString();
                else
                    throw new InvalidOperationException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBookAsync(string bookId)
        {
            try
            {
                var guid = new Guid(bookId);
                await dataService.DeleteBookAsync(guid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RentDTO>> GetAllUserRentsByUserIdAsync(string userId)
        {
            try
            {
                return mapper.Map<IEnumerable<RentDTO>>(await dataService.GetAllUserRentsByUserIdAsync(new Guid(userId)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> CreateBookRentAsync(RentToCreateDTO rentToCreate)
        {
            try
            {
                var rentModel = mapper.Map<RentModel>(rentToCreate);
                rentModel.RentStarted = DateTime.UtcNow;
                rentModel.RentId = Guid.NewGuid();

                return await dataService.CreateBookRentAsync(rentModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CloseBookRentAsync(RentToCloseDTO rentToClose)
        {
            try
            {
                var rentModel = mapper.Map<RentModel>(rentToClose);
                rentModel.RentClosed = DateTime.UtcNow;

                await dataService.CloseBookRentAsync(rentModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}