using System.ComponentModel.DataAnnotations;
namespace LojaFemme.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name = "Nome Completo :")]
        [Required(ErrorMessage = "Preenchimento Obrigatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo deve conter pelo menos 3 caracteres e no máximo 100 caracteres")]
        public string? Nome { get; set; }



        [Display(Name = "Email :")]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Preencha o campo com um e-mail válido")]
        [StringLength(80, MinimumLength = 8, ErrorMessage = "O campo deve conter pelo menos 8 caracteres e no máximo 80 caracteres")]
        public string? Email { get; set; }



        [Display(Name = "Telefone (exemplo formato 01199991122): ")]
        [Required(ErrorMessage = "Preenchimento Obrigatorio - Exemplo formato 01199991122")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O campo deve conter entre 11 e 15 caracteres")]
        public string? Telefone { get; set; }


        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }


        [Display(Name = "CPF: ")]
        [Required(ErrorMessage = "Preenchimento Obrigatorio - somente numeros")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo deve conter somente numeros e exatamente 11 caracteres")]
        public string? Cpf { get; set; }

        public Endereco? Endereco { get; set; }

        public virtual ICollection<Pedido> ?Pedidos { get; set; }
    }
}