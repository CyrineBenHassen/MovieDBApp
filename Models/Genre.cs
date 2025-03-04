using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Relation One-to-Many avec Movie
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
