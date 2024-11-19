using library.DTOs;

namespace library.Repository.AuthorRepo
{
    public interface IAuthorrepo
    {
        public List<AuthorListDTO> GetAll();
        public AuthorListDTO Getbyid(int id);
        public AuthorDTO Add(AuthorDTO authordto);
        public AuthorDTO Update(int id,AuthorDTO authordto);
        public AuthorDTO Delete(int id);
    }
}
