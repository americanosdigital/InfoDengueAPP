using Microsoft.EntityFrameworkCore;
using InfoDengueAPP.Domain.Entities;

namespace InfoDengueAPP.INFRASTRUCTURE.DbContexts
{
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
