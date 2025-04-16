using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Enums;

namespace Eclipseworks.Domain.Entities
{
    public sealed class ProjectTaskUpdateHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriorityStatus Priority { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
