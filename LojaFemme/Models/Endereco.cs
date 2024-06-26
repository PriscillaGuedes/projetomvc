using System.ComponentModel.DataAnnotations;

namespace LojaFemme.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatorio")]
        [StringLength(100)]
        public string? Rua { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter no mínimo 2 caracteres e no máximo 50 caracteres")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatorio")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo deve conter somente a sigla do estado com extamente 2 caracteres")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "Preenchimento Obrigatorio")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo deve conter somente numeros e exatamente 8 caracteres")]
        public string? Cep { get; set; }
    }
}
