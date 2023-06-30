using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API_ZAP.Model
{
    public class DBZap : DbContext
    {
        public DBZap(DbContextOptions<DBZap> options) : base(options)
        {
        }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Funcionario>? Funcionarios { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Pedidos>? Pedidos { get; set; }

    }
}
