using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // object from bookcontext itname :_context : =>
        private readonly BookConText _context;
        public BookController(BookConText bookConText)
        {
            //      ==
            _context = bookConText;
            
        }
        //Get :Get ALL Databeas When use Url :Api/book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDB>>> GetResult()
        {
            return await _context.DBbookstor.ToListAsync();
        }

        //Get Book use Id :
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDB>> GetBookide( int id)
        {
            var book = await _context.DBbookstor.FindAsync(id);
            
            if(book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }

        // Add Books
        [HttpPost]
        public async Task<ActionResult<BookDB>> Psotbook([FromBody]BookDB book)
        {
            _context.DBbookstor.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Getbook", new { Id = book.Id }, book);
        }

        //Delet book use Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletBook(int id)
        {
            var book = await _context.DBbookstor.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
                return NoContent();
            }

        }

        // Updet informition :
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook (BookDB dB ,int id)
        {
           if(id != dB.Id)
            {
                return BadRequest();
            }
            else
            {
               _context.Entry(dB).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!BookCheck(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //if you Send Write Id , this Fn Get True :
        private bool BookCheck (int id)
        {
            return _context.DBbookstor.Any(x => x.Id == id);
        }

       
    }
}
