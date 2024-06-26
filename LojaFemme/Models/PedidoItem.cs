namespace LojaFemme.Models
{
    public class PedidoItem
    {
        public int PedidoItemId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public virtual Pedido? Pedido { get; set; }
        public virtual Produto? Produto { get; set; }

    }
}
