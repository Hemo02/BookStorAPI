using Microsoft.EntityFrameworkCore;

namespace BooksApi.Models
{
    public class BookConText : DbContext
    {
        internal object bookdb;

        public BookConText(DbContextOptions<BookConText> contextOptions) :base(contextOptions)
        {
            
        }
       public DbSet<BookDB> DBbookstor{ get; set;}

    }
}
