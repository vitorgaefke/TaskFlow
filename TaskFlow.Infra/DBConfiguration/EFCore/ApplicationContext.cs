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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly); // Aplica todas as configurações de entidade do assembly atual)
        }
    }
}
