using System.ComponentModel.DataAnnotations;

namespace SaleSistemMvc.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Nome")] 
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Preço")]
        public decimal? Price { get; set; }

    }
}
