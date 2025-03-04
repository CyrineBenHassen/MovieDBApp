using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class MembreshipType
    {
     
        
            [Key]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            public decimal SignUpFee { get; set; }
            public int DurationInMonth { get; set; }
            public float DiscountRate { get; set; }

            //// Relation One-to-Many avec Customer
            public ICollection<Customer> Customers { get; set; } = new List<Customer>();

        }

    }

