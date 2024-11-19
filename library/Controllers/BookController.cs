using library.DTOs;
using library.Repository.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookrepo _repo;

        public BookController(IBookrepo repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var book = _repo.GetAll();
            if (book == null)
            { 
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            var book = _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(BookDTO bookDTO)
        {
            _repo.Add(bookDTO);
            return Created();
        }

        [HttpPut]
        public IActionResult updatebook(int id, BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _repo.Update(id, bookDTO);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("AddDatatobook")]
        public IActionResult Addalldata (BookToReturnDTO bookDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var books = _repo.AddBookandautandgen(bookDTO);
            if(books == null)
            {
                return NotFound();
            }
            return Created();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var del = _repo.Delete(id);
            if(del == null)
            {
                return NotFound();
            }
            return Ok(del);
        }
    }
}
