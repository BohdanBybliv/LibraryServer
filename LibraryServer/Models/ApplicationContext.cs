using Microsoft.EntityFrameworkCore;

namespace LibraryServer.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasData(
            //    new Book[]
            //    {
            //        new Book { Id = 1, Title = "Dracula", Author = "Bram Stoker", Content = "Dracula by Bram Stoker", Cover = "fhjdnfdgvg", Genre = "Journeys" },
            //        new Book { Id = 2, Title = "Joseph and His Brothers", Author = "Thomas Mann", Content = "Joseph and His Brothers by Thomas Mann", Cover = "edynbsfdcjcmnrt", Genre = "Journeys" },
            //        new Book { Id = 3, Title = "The Moonstone", Author = "Wilkie Collins", Content = "Wilkie Collins, The Moonstone.", Cover = "bzdfjc,ykujcthrtd", Genre = "Detective" },
            //        new Book { Id = 4, Title = "The Call of the Wild", Author = "Jack London", Content = "The Call of the Wild by Jack London", Cover = "sxfhbtfsdgsf", Genre = "Adventure" },
            //        new Book { Id = 5, Title = "The Mystery of a Hansom Cab", Author = "Fergus Hume", Content = "Fergus Hume, The Mystery of a Hansom Cab.", Cover = "eyjhgdszhdbd", Genre = "Detective" },
            //        new Book { Id = 6, Title = "Odyssey", Author = "Homer", Content = "Odyssey by Homer", Cover = "jkbsvdi,nc", Genre = "Adventure" },
            //        new Book { Id = 7, Title = "Around the World in Eighty Days", Author = "Jules Verne", Content = "Around the World in Eighty Days by Jules Verne", Cover = "iakghbdvasioudhfk", Genre = "Adventure" },
            //        new Book { Id = 8, Title = "The Book of Disquiet", Author = "Fernando Pessoa", Content = "The Book of Disquiet by Fernando Pessoa", Cover = "dgnbzzerhzbds", Genre = "Journeys" },
            //        new Book { Id = 9, Title = "The Hound of the Baskervilles", Author = "Arthur Conan Doyle", Content = "Arthur Conan Doyle, The Hound of the Baskervilles", Cover = "thbdfszghjtfd", Genre = "Detective" },
            //        new Book { Id = 10, Title = "Inland", Author = "Gerald Murnane", Content = "Inland by Gerald Murnane", Cover = "wrshgfSzehrhegfs", Genre = "Journeys" }
            //    });

            //modelBuilder.Entity<Rating>().HasData(
            //    new Rating[]
            //    {
            //        new Rating { Id = 1, Score = 2, BookId = 1 },
            //        new Rating { Id = 2, Score = 3, BookId = 2 },
            //        new Rating { Id = 3, Score = 4, BookId = 3 },
            //        new Rating { Id = 4, Score = 5, BookId = 4 },
            //        new Rating { Id = 5, Score = 3, BookId = 5 },
            //        new Rating { Id = 6, Score = 1, BookId = 6 },
            //        new Rating { Id = 7, Score = 2, BookId = 7 },
            //        new Rating { Id = 8, Score = 3, BookId = 8 },
            //        new Rating { Id = 9,  Score = 4, BookId = 9 },
            //        new Rating { Id = 10, Score = 5, BookId = 10 },
            //        new Rating { Id = 11, Score = 2, BookId = 2  },
            //        new Rating { Id = 12, Score = 3, BookId = 3 },
            //        new Rating { Id = 13, Score = 4, BookId = 4 },
            //        new Rating { Id = 14, Score = 5, BookId = 5 },
            //        new Rating { Id = 15, Score = 3, BookId = 6 },
            //        new Rating { Id = 16, Score = 1, BookId = 7 },
            //        new Rating { Id = 17, Score = 2, BookId = 7 },
            //        new Rating { Id = 18, Score = 3, BookId = 8 },
            //        new Rating { Id = 19, Score = 4, BookId = 10 },
            //    });

            //modelBuilder.Entity<Review>().HasData(
            //    new Review[]
            //    {
            //        new Review { Id = 1, Message = "Message1", Reviewer = "Reviewer1", BookId = 1 },
            //        new Review { Id = 2, Message = "Message2", Reviewer = "Reviewer2", BookId = 1 },
            //        new Review { Id = 3, Message = "Message3", Reviewer = "Reviewer3", BookId = 1 },
            //        new Review { Id = 4, Message = "Message4", Reviewer = "Reviewer4", BookId = 1 },
            //        new Review { Id = 5, Message = "Message5", Reviewer = "Reviewer5", BookId = 1 },
            //        new Review { Id = 6, Message = "Message6", Reviewer = "Reviewer6", BookId = 1 },
            //        new Review { Id = 7, Message = "Message7", Reviewer = "Reviewer7", BookId = 1 },
            //        new Review { Id = 8, Message = "Message8", Reviewer = "Reviewer8", BookId = 1 },
            //        new Review { Id = 9, Message = "Message9", Reviewer = "Reviewer9", BookId = 1 },
            //        new Review { Id = 10, Message = "Message10", Reviewer = "Reviewer10", BookId = 1 },
            //        new Review { Id = 11, Message = "Message11", Reviewer = "Reviewer11", BookId = 1 },
            //        new Review { Id = 12, Message = "Message12", Reviewer = "Reviewer12", BookId = 1 },

            //        new Review { Id = 13, Message = "Message2", Reviewer = "Reviewer2", BookId = 2 },
            //        new Review { Id = 14, Message = "Message3", Reviewer = "Reviewer3", BookId = 3 },
            //        new Review { Id = 15, Message = "Message4", Reviewer = "Reviewer4", BookId = 4 },
            //        new Review { Id = 16, Message = "Message5", Reviewer = "Reviewer5", BookId = 5 },
            //        new Review { Id = 17, Message = "Message6", Reviewer = "Reviewer6", BookId = 6 },
            //        new Review { Id = 18, Message = "Message7", Reviewer = "Reviewer7", BookId = 8 },
            //        new Review { Id = 19, Message = "Message8", Reviewer = "Reviewer8", BookId = 2 },
            //        new Review { Id = 20, Message = "Message9", Reviewer = "Reviewer9", BookId = 3 },
            //        new Review { Id = 21, Message = "Message10", Reviewer = "Reviewer10", BookId = 5 },

            //        new Review { Id = 22, Message = "Message1", Reviewer = "Reviewer1", BookId = 7 },
            //        new Review { Id = 23, Message = "Message12", Reviewer = "Reviewer2", BookId = 7 },
            //        new Review { Id = 24, Message = "Message13", Reviewer = "Reviewer3", BookId = 7 },
            //        new Review { Id = 25, Message = "Message14", Reviewer = "Reviewer4", BookId = 7 },
            //        new Review { Id = 26, Message = "Message15", Reviewer = "Reviewer5", BookId = 7 },
            //        new Review { Id = 27, Message = "Message16", Reviewer = "Reviewer6", BookId = 7 },
            //        new Review { Id = 28, Message = "Message17", Reviewer = "Reviewer7", BookId = 7 },
            //        new Review { Id = 29, Message = "Message18", Reviewer = "Reviewer8", BookId = 7 },
            //        new Review { Id = 30, Message = "Message19", Reviewer = "Reviewer9", BookId = 7 },
            //        new Review { Id = 31, Message = "Message20", Reviewer = "Reviewer10", BookId = 7 },
            //        new Review { Id = 32, Message = "Message22", Reviewer = "Reviewer11", BookId = 7 },
            //    });
        }
    }
}
