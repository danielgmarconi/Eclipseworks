using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public User(int id,
                    string name,
                    string password) 
        {
            Id = id;
            Name = name;
            Email = password;
        }
    }
}
