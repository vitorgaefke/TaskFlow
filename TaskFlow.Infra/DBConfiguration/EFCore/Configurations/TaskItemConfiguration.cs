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
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> entity)
        {
            entity.HasOne(task => task.Status)
                    .WithMany() // Um Status pode ter muitos TaskItems
                    .HasForeignKey(task => task.StatusId) // Chave estrangeira em TaskItem
                    .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata
        }
    }
}
