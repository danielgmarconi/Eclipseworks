using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
