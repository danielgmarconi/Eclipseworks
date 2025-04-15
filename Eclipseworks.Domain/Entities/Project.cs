using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Entities
{
    public sealed class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
