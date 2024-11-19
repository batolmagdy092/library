    using library.Models;
    using Microsoft.EntityFrameworkCore;

    namespace library.Data
    {
         public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Genre> Genres { get; set; }
        }
    }
