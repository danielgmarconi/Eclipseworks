using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Entities
{
    public sealed class ProjectTask : Entity
    {
        public int ProjectId { get; set; }
        public ICollection<Project> Project { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
