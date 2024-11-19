using System.ComponentModel.DataAnnotations;

namespace library.DTOs
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }
        public DateTime publishedyear { get; set; } 
        public List<int>? Authorid { get; set; }
        public List<int>? Genersid { get; set; }
    }

    public class BookToReturnDTO
    {
        [Required]
        public string Title { get; set; }
        public DateTime publishedyear { get; set; }
        public List<AuthorDTO>? Authors{ get; set; }
        public List<GenreDTO>? Geners { get; set; }
    }
}
