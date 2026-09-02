using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;


namespace TaskFlow.Infra.DBConfiguration.EFCore.Configurations
{
    public class TaskItemStatusConfiguration : IEntityTypeConfiguration<TaskItemStatus>
    {
        public void Configure(EntityTypeBuilder<TaskItemStatus> entity)
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
        }
    }
}
