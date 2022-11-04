using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class BookDB
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        //[StringLength (maximumLength:150,MinimumLength =10)]
        public string Author { get; set; }
       // [StringLength(maximumLength:90,MinimumLength =10)]
        public string Discription { get; set; }
       // [StringLength(maximumLength:200,MinimumLength =10)]

    }
}
