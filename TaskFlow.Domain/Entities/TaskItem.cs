using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int StatusId { get; set; } = 1; // Valor padrão para "TODO"
        public TaskItemStatus Status { get; set; } = null!;
    }
}
