using System.ComponentModel.DataAnnotations;

namespace SaleSistemMvc.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Comprador")]
        public UserAccount? Buyer { get; set; }

        [Required]
        [Display(Name ="Data da compra")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Produto")]
        public Product? ProductBuyed { get; set; }
    }
}
