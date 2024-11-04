using Microsoft.EntityFrameworkCore;
using static AgroInfoBack.Models.PlantacaoModel;

namespace AgroInfoBack.Context
{
    public class AgroContext : DbContext
    {
        public AgroContext(DbContextOptions<AgroContext> options) : base(options) { }

        public DbSet<Plantacao> Plantacoes { get; set; }
        public DbSet<Agrotoxico> Agrotoxicos { get; set; }
        public DbSet<Fertilizante> Fertilizantes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plantacao>()
            .HasMany(p => p.Agrotoxicos)
            .WithOne(a => a.Plantacao)
            .HasForeignKey(a => a.PlantacaoId);

        modelBuilder.Entity<Plantacao>()
            .HasMany(p => p.Fertilizantes)
            .WithOne(f => f.Plantacao)
            .HasForeignKey(f => f.PlantacaoId);
    }
}
}