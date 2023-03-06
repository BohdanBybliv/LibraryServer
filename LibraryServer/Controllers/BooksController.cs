using LibraryServer.DTOs;
using LibraryServer.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("books")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAll(string? order)
        {
            var response = await _bookService.GetAll(order);

            if (response.IsSuccess) return Ok(response.Result);

            return BadRequest();
        }

        [HttpGet]
        [Route("recommended")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetRecommende(string? genre)
        {
            var response = await _bookService.GetRecommended(genre);

            if (response.IsSuccess) return Ok(response.Result);

            return BadRequest();
        }

        [HttpGet]
        [Route("books/{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBookById(int? id)
        {
            var response = await _bookService.GetById(id);

            if (response.IsSuccess) return Ok(response.Result);

            if (response.StatusCode == Extensions.StatusCode.NotFound) return NotFound();

            return BadRequest();
        }

        [HttpDelete]
        [Route("books/{id}")]
        public async Task<ActionResult> Delete(int? id, string secret)
        {
            var response = await _bookService.DeleteById(id, secret);

            if (response.IsSuccess) return Ok();

            if (response.StatusCode == Extensions.StatusCode.NotFound) return NotFound();

            if (response.StatusCode == Extensions.StatusCode.Forbidden) return StatusCode(403, "Secret key is incorect");

            return BadRequest();
        }

        [HttpPost]
        [Route("books/save")]
        public async Task<ActionResult<int>> AddBook(BookCreationDTO bookDTO)
        {
            var response = await _bookService.CreateBook(bookDTO);

            if (response.IsSuccess) return Ok(response.Result);

            return BadRequest();
        }

        [HttpPost]
        [Route("books/review")]
        public async Task<ActionResult<int>> AddReview(ReviewCreationDTO reviewDTO)
        {
            var response = await _bookService.CreateReview(reviewDTO);

            if (response.IsSuccess) return Ok(response.Result);

            return BadRequest();
        }

        [HttpPost]
        [Route("books/rating")]
        public async Task<ActionResult<int>> AddRating(RatingCreationDTO ratingDTO)
        {
            var response = await _bookService.CreateRating(ratingDTO);

            if (response.IsSuccess) return Ok(response.Result);

            return BadRequest();
        }
    }
}
