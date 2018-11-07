using Microsoft.EntityFrameworkCore;

namespace TJMT.Docker.DotNet.Samples.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {
        }

        public DbSet<Tabela> Tabela { get; set; }

    }

    public class Tabela
    {
        public int Id { get; set; }
        public string Coluna { get; set; }
    }
}
