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

        // Exemplo futuro:
        // public DbSet<Usuario> Usuarios { get; set; }
    }
}
