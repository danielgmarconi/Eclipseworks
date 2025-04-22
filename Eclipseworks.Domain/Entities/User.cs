using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<ProjectTask>? ProjectTasks { get; set; }
        public ICollection<ProjectTaskComment>? ProjectTaskComments { get; set; }
        public User(int id,
                    string name,
                    string email,
                    string password)
        {
            ValidateDomain(name, email, password);
            Id = id; 
            Name = name;
            Email = email;
            Password = password;
        }
        public void Update(int id,
                           string name,
                           string password)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            ValidateDomain(name, Email, password);
            Id = id;
            DateModification =  DateTime.Now;
        }
        public void PasswordUpdate(string password)
        {
            Password = password;
        }
        private void ValidateDomain(string name,
                                    string? email,
                                    string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required");
            DomainExceptionValidation.When(!(name.Length >= 3 && name.Length <= 200),
                                           "Invalid name, must be greater than or equal to 3 and less than 200 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                                           "Invalid email. Name is required");
            DomainExceptionValidation.When(!(email.Length >= 10 && email.Length <= 250),
                                            "Invalid email, must be greater than or equal to 10 and less than 250 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password),
                                           "Invalid password. Name is required");
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
