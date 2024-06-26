using System.ComponentModel.DataAnnotations;

namespace LojaFemme.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }


        [Required]
        [StringLength(100)]
        public string? Descricao { get; set; }


        [Required]
        [Range(0.01, double.MaxValue)]
        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public string? ImagemUrl { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
        public virtual Estoque? Estoque { get; set; }
    }
}
