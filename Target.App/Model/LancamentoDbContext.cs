using Microsoft.EntityFrameworkCore;

namespace Target.App.Model
{
    public class LancamentoDbContext: DbContext
    {

        public LancamentoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Lancamento> Lancamentos { get; set; }

    }
}
