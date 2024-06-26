namespace LojaFemme.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; set; }
        public string? Status { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public virtual ICollection<PedidoItem>? PedidoItems { get; set; }

    }
}
