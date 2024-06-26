namespace LojaFemme.Models
{
    public class Estoque
    {
        public int EstoqueId { get; set; }
        public int ProdutoID { get; set; }
        public virtual Produto? Produto { get; set; }

        public int Quantidade { get; set; }
        public DateTime LastUpdated { get; set; }


        public bool AtualizarQuantidade(int quantidade)
        {
            if (Quantidade + quantidade >= 0)
            {
                Quantidade += quantidade;
                return true;
            }
            return false;

        }
    }
}
