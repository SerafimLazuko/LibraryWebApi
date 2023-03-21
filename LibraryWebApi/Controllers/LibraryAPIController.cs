using Library.BLL.DTO;
using Library.BLL.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryAPIController : ControllerBase
    {
        private readonly IBookRentService bookRentService;

        public LibraryAPIController(IBookRentService _bookRentService)
        {
            bookRentService = _bookRentService;
        }

        [HttpGet("Books")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            try
            {
                var result = await bookRentService.GetAllBooksAsync();

                if (result == null || !result.Any())
                    return StatusCode(StatusCodes.Status204NoContent, "No Books found");

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Books/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(string id)
        {
            try
            {
                var result = await bookRentService.GetBookByIdAsync(id);

                if(result != null)
                {
                    return Ok(result);
                }

                return StatusCode(StatusCodes.Status204NoContent, "Book not found");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Books/IBAN")]
        public async Task<IActionResult> GetBookByIBANAsync(string iban)
        {
            try
            {
                var result = await bookRentService.GetBookByIBANAsync(iban);

                if (result != null)
                {
                    return Ok(result);
                }

                return StatusCode(StatusCodes.Status204NoContent, "Book not found");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddNewBookAsync(BookToAddDTO bookToAddDTO)
        {
            try
            {
                return Ok(await bookRentService.AddNewBookAsync(bookToAddDTO));
            } 
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("EditBook/{id}")]
        public async Task<IActionResult> EditBookAsync(BookToEditDTO bookToEditDTO)
        {
            try
            {
                var result = await bookRentService.EditBookInfoAsync(bookToEditDTO);

                if (result != string.Empty)
                    return Ok(result);
                else
                    return BadRequest("Please verify book id");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBookAsync(string id)
        {
            try
            {
                await bookRentService.DeleteBookAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Rents/{userId}")]
        public async Task<IActionResult> GetAllRentsByUserId(string userId)
        {
            try
            {
                return Ok(await bookRentService.GetAllUserRentsByUserIdAsync(userId));
            } 
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Rents/NewRent")]
        public async Task<IActionResult> CreateRentAsync(RentToCreateDTO rentToCreateDTO)
        {
            try
            {
                return Ok(await bookRentService.CreateBookRentAsync(rentToCreateDTO));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Rents/CloseRent")]
        public async Task<IActionResult> CloseRentAsync(RentToCloseDTO rentToCloseDTO)
        {
            try
            {
                await bookRentService.CloseBookRentAsync(rentToCloseDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
