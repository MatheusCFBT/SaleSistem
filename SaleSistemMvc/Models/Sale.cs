using System.ComponentModel.DataAnnotations;

namespace SaleSistemMvc.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UserAccount? Buyer { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public List<Product>? ProductsBuyed { get; set; }
    }
}
