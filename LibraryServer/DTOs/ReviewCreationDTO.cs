namespace LibraryServer.DTOs
{
    public class ReviewCreationDTO
    {
        public string Message { get; set; }
        public string Reviewer { get; set; }
        public int BookId { get; set; }
    }
}
