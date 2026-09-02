using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities
{
    public class TaskItemStatus
    {
        public int Id { get; set; }
        public required string Slug { get; set; }
        public required string Name { get; set; }
        public required string Color { get; set; }
    }
}
