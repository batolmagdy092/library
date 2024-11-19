using System.ComponentModel.DataAnnotations;

namespace library.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
