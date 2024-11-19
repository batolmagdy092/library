using library.DTOs;

namespace library.Repository.BookRepo
{
    public interface IBookrepo
    {
        public List<BookToReturnDTO> GetAll();
        public BookToReturnDTO GetById(int id);
        public void Add(BookDTO bookDTO);
        public BookDTO Update(int id,BookDTO bookDTO);
        public BookDTO Delete(int id);
        public BookToReturnDTO AddBookandautandgen (BookToReturnDTO bookDTO);
    }
}
