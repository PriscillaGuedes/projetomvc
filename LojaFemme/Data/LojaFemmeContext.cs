using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaFemme.Models;

namespace LojaFemme.Data
{
    public class LojaFemmeContext : DbContext
    {
        public LojaFemmeContext (DbContextOptions<LojaFemmeContext> options)
            : base(options)
        {
        }

        public DbSet<LojaFemme.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<LojaFemme.Models.Administrador> Administrador { get; set; } = default!;
        public DbSet<LojaFemme.Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<LojaFemme.Models.Endereco> Endereco { get; set; } = default!;
        public DbSet<LojaFemme.Models.Estoque> Estoque { get; set; } = default!;
        public DbSet<LojaFemme.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<LojaFemme.Models.Pagamento> Pagamento { get; set; } = default!;
        public DbSet<LojaFemme.Models.Pedido> Pedido { get; set; } = default!;
        public DbSet<LojaFemme.Models.PedidoItem> PedidoItem { get; set; } = default!;
        public DbSet<LojaFemme.Models.Produto> Produto { get; set; } = default!;
    }
}
