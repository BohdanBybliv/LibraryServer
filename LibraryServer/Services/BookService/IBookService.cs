using LibraryServer.DTOs;
using LibraryServer.Extensions;

namespace LibraryServer.Services.BookService
{
    public interface IBookService
    {
        public Task<ServiceMethodContentResult<IEnumerable<BookDTO>>> GetAll(string? order);
        public Task<ServiceMethodContentResult<IEnumerable<BookDTO>>> GetRecommended(string? genre);
        public Task<ServiceMethodContentResult<BookDetailsDTO>> GetById(int? id);
        public Task<ServiceContentResult> DeleteById(int? id, string? secretKey);
        public Task<ServiceMethodContentResult<int>> CreateBook(BookCreationDTO bookDTO);
        public Task<ServiceMethodContentResult<int>> CreateReview(ReviewCreationDTO reviewDTO);
        public Task<ServiceMethodContentResult<int>> CreateRating(RatingCreationDTO ratingDTO);
    }
}
