using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class Author
    {
        [Key]
        public int AId { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone(ErrorMessage = "Enter Valid number")]
        public string? phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string? email { get; set; }
        public ICollection<Book>? books { get; set; }


    }
}
