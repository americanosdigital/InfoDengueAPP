using Microsoft.EntityFrameworkCore;
using InfoDengueAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace InfoDengueAPP.INFRASTRUCTURE.DbContexts
{

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=InfoDengue;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitante>()
                .HasIndex(s => s.Cpf)
                .IsUnique();

            modelBuilder.Entity<Relatorio>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Municipio)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(r => r.CodigoIbge)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(r => r.Arbovirose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(r => r.TotalCasos)
                    .IsRequired();

                entity.Property(r => r.DataSolicitacao)
                    .IsRequired();

                // Relacionamento com Solicitante
                entity.HasOne(r => r.Solicitante)
                    .WithMany(s => s.Relatorios)
                    .HasForeignKey(r => r.SolicitanteId);
            });
        }
    }
}
