using BooksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        
        private readonly BookConText _context;
        public BooksController(BookConText bookConText)
        {
            
            _context = bookConText;

        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDB>>> GetResult()
        {
            return await _context.DBbookstor.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDB>> GetBookide(int id)
        {
            var book = await _context.DBbookstor.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<BookDB>> Psotbook([FromBody] BookDB book)
        {
            _context.DBbookstor.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Getbook", new { Id = book.Id }, book);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletBook(int id)
        {
            var book = await _context.DBbookstor.FindAsync(id);
            if (book == null)
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

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(BookDB dB, int id)
        {
            if (id != dB.Id)
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
                if (!BookCheck(id))
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

        
        private bool BookCheck(int id)
        {
            return _context.DBbookstor.Any(x => x.Id == id);
        }

    }
}
