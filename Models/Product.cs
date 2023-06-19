using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Brand { get; set; }

        [Required]
        [StringLength(25)]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public bool ActiveFlag { get; set; }

    }
}
