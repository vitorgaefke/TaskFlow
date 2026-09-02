using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Infra.DBConfiguration.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<TesteUsuario> TesteUsuario { get; set; }
        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<TaskItemStatus> TaskItemStatus { get; set; }
        // Exemplo futuro:
        // public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Chamada ao método base para garantir que a configuração padrão seja aplicada

            // Configuração da entidade TaskItemStatus
            modelBuilder.Entity<TaskItemStatus>(entity =>
            {
                entity.Property(e => e.Slug).HasMaxLength(30).IsRequired(); // Garante que o Slug seja obrigatório e tenha no máximo 30 caracteres
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(); // Garante que o Name seja obrigatório e tenha no máximo 100 caracteres
                entity.Property(e => e.Color).HasMaxLength(7); // Garante que o Color tenha no máximo 7 caracteres (ex: #FFFFFF)

                entity.HasIndex(e => e.Slug).IsUnique(); // Garante que o Slug seja único

                entity.HasData(
                    new { Id = 1, Slug = "TODO", Name = "A Fazer", Color = "#9AA0A6" },
                    new { Id = 2, Slug = "IN_PROGRESS", Name = "Em Andamento", Color = "#4A90D9" },
                    new { Id = 3, Slug = "DONE", Name = "Feito", Color = "#3DA35D" }
                ); // Dados iniciais para a tabela TaskItemStatus
            });

            // Configuração da entidade TaskItem
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasOne(task => task.Status)
                    .WithMany() // Um Status pode ter muitos TaskItems
                    .HasForeignKey(task => task.StatusId) // Chave estrangeira em TaskItem
                    .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata
            }); // Configuração da relação entre TaskItem e TaskItemStatus
        }
    }
}
