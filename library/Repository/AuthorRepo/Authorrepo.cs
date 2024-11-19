using library.Data;
using library.DTOs;
using library.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace library.Repository.AuthorRepo
{
    public class Authorrepo : IAuthorrepo
    {
        private readonly AppDbContext _context;
        public Authorrepo(AppDbContext context) 
        { 
            _context = context;
        }
        public AuthorDTO Add(AuthorDTO authordto)
        {
            var book = _context.Books.Where(b=> authordto.Bookid.Contains(b.BId)).ToList();
            var auth = new Author
            {
                Name = authordto.Name,
                email = authordto.email,
                phone = authordto.phone,
                books = book,
            };
            _context.Authors.Add(auth);
            _context.SaveChanges();
            return authordto;
        }

        public AuthorDTO Delete(int id)
        {
            var auth = _context.Authors.Find(id);
            var auths = new AuthorDTO
            {
                Name = auth.Name,
                email = auth.email,
                phone = auth.phone,
            };
            _context.Authors.Remove(auth);
            _context.SaveChanges();
            return auths;
        }

        public List<AuthorListDTO> GetAll()
        {
            var auth = _context.Authors.Include(a => a.books)
                .Select(
                b => new AuthorListDTO
                {
                    Name = b.Name,
                    email = b.email,
                    phone = b.phone,
                    Books = b.books.Select(x=> new BookDTO
                    {
                       Title = x.Title,
                       publishedyear = x.publishedyear,
                    }).ToList(),
                }).ToList();
            return auth;
        }

        public AuthorListDTO Getbyid(int id)
        {
            var auth = _context.Authors.Include(b=>b.books).FirstOrDefault(x=>x.AId == id);
            var auths = new AuthorListDTO
            {
                Name = auth.Name, 
                email = auth.email,
                phone = auth.phone,
                Books = auth.books.Select( y=> new BookDTO
                {
                   Title = y.Title,
                  publishedyear = y.publishedyear,
                }).ToList(),
            };
            return auths;
        }

        public AuthorDTO Update(int id, AuthorDTO authordto)
        {
            var auth = _context.Authors.Find(id);
       
               auth. Name = authordto.Name;
              auth.email = authordto.email;
            auth.phone = authordto.phone;
                if(authordto.Bookid.Count > 0)
            {
             auth.books = _context.Books.Where(b => authordto.Bookid.Contains(b.BId)).ToList();
            }
            _context.Authors.Update(auth);
            _context.SaveChanges();
             return authordto;
        }
    }
}
