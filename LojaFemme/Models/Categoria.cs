using System.ComponentModel.DataAnnotations;

namespace LojaFemme.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }
        public virtual ICollection<Produto> ?Produtos { get; set; }
    }
}
