using library.Data;
using library.DTOs;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Repository.BookRepo
{
    public class Bookrepo : IBookrepo
    {
        private readonly AppDbContext _context;
        public Bookrepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(BookDTO bookDTO)
        {
            var auth = _context.Authors.Where(a=> bookDTO.Authorid.Contains(a.AId)).ToList();
            var gen = _context.Genres.Where(g=> bookDTO.Genersid.Contains(g.GId)).ToList();
            var book = new Book
            {
                Title = bookDTO.Title,
                publishedyear = bookDTO.publishedyear,
               authors = auth,
               genres = gen,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public BookDTO Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return null;
            }

            var books = new BookDTO
            {
                Title = book.Title,
                publishedyear =book.publishedyear,
            };
            _context.Books.Remove(book);
            _context.SaveChanges();
            return books;
        }

        public List<BookToReturnDTO> GetAll()
        {
            var book = _context.Books.Include(a => a.authors).Include(a => a.genres)
                .Select(b => new BookToReturnDTO
                {
                    Title = b.Title,
                    publishedyear = b.publishedyear,
                    //return data in database and select this data from DTO
                    Authors = b.authors.Select(x => new AuthorDTO
                    {
                      Name = x.Name,
                      email = x.email,
                      phone = x.phone,
                    }).ToList(),
                    Geners = b.genres.Select(y=> new GenreDTO
                    {
                        Name = y.Name,
                    }).ToList(),
                }).ToList();
            return book;
        }

        // get by id
        public BookToReturnDTO GetById(int id)
        {
            var book = _context.Books.Include(a => a.authors).Include(g => g.genres)
                .FirstOrDefault(x=>x.BId==id);
            var books = new BookToReturnDTO
            {
              Title = book.Title,
              publishedyear = book.publishedyear,
              Authors = book.authors.Select(d=> new AuthorDTO
              {
                  Name=d.Name,
                  email=d.email,
                  phone = d.phone,
              }).ToList(),
              Geners = book.genres.Select(s=> new GenreDTO
              {
                  Name = s.Name,
              }).ToList(),
            };
            return books;
        }

        public BookDTO Update(int id  ,BookDTO bookDTO)
        {
            //update book by id 
            var book = _context.Books.Find(id);
           
            book.Title = bookDTO.Title;
            book.publishedyear = bookDTO.publishedyear;
            if(bookDTO.Authorid.Count>0) // author is existiong in list of author 
            {
                book.authors = _context.Authors.Where(a => bookDTO.Authorid.Contains(a.AId)).ToList();
            }
           if(bookDTO.Genersid.Count>0) // genre is existiong in list of genre 
            {
                book.genres = _context.Genres.Where(g => bookDTO.Genersid.Contains(g.GId)).ToList();
            }
            _context.Update(book);
            _context.SaveChanges();
            return bookDTO;
        }

        public BookToReturnDTO AddBookandautandgen(BookToReturnDTO bookDTO)
        {
            var book = new Book
            {
                Title=bookDTO.Title,
                publishedyear=bookDTO.publishedyear,
                authors = bookDTO.Authors.Select(a=> new Author // add new author in database
                {
                    Name = a.Name,
                    email = a.email,
                    phone=a.phone,
                }).ToList(),
                genres = bookDTO.Geners.Select(g=> new Genre
                {
                    Name = g.Name,
                }).ToList(),
            };
          var bookres =  _context.Books.Add(book);
            if(bookres == null)
            {
                return null;
            }
            _context.SaveChanges();
            return bookDTO;
        }
    }
}
