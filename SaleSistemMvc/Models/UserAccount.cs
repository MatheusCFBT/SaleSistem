using System.ComponentModel.DataAnnotations;

namespace SaleSistemMvc.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato inválido.")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^[1-9]{2}[0-9]{9}$", ErrorMessage = "O campo {0} está em formato inválido.")]
        [Display(Name = "Celular")]

        public string? Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "O campo {0} está em formato inválido.")]
        [Display(Name = "Cep")]

        public string? PostalCode { get; set; }

    }
}
