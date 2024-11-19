using library.Models;
using System.ComponentModel.DataAnnotations;

namespace library.DTOs
{
    public class AuthorDTO
    {
        [Required]
        public string Name { get; set; }
        [Phone(ErrorMessage = "Enter Valid number")]
        public string? phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string? email { get; set; }

        public List<int>? Bookid { get; set; }
    }

    public class AuthorListDTO
    {
        [Required]
        public string Name { get; set; }
        [Phone(ErrorMessage = "Enter Valid number")]
        public string? phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string? email { get; set; }

        public List<BookDTO>? Books { get; set; }
    }
}
