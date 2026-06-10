using EcoColeta.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoColeta.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TipoResiduo> TiposResiduos { get; set; }

        public DbSet<PontoColeta> PontosColeta { get; set; }

        public DbSet<ColetaResiduo> ColetasResiduos { get; set; }
    }
}