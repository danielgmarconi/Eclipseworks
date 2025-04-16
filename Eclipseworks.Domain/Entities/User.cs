using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<Project>? Projects { get; set; }
        public User(int id,
                    string name,
                    string email,
                    string password)
        {
            Id = id; 
            Name = name;
            Email = email;
            Password = password;
        }
        public void PasswordUpdate(string password)
        {
            Password = password;
        }
    }
}
