using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Entities
{
    public sealed class ProjectTaskComment : Entity
    {
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
