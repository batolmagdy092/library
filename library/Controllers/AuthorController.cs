using library.DTOs;
using library.Repository.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorrepo _repo;

        public AuthorController(IAuthorrepo repo)
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
            var book = _repo.Getbyid(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(AuthorDTO authorDTO)
        {
            var books = _repo.Add(authorDTO);

            if (books == null)
            {
                return NotFound();
            }
            return Created();
        }

        [HttpPut]
        public IActionResult updatebook(int id, AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _repo.Update(id, authorDTO);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var del = _repo.Delete(id);
            if (del == null)
            {
                return NotFound();
            }
            return Ok(del);
        }
    }
}