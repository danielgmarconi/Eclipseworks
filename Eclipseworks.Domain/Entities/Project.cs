using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Domain.Entities
{
    public sealed class Project : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<ProjectTask>? ProjectTasks { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Project(string name,
                       string description,
                       DateTime startDate,
                       DateTime endDate)
        {
            ValidateDomain(name, description, startDate, endDate);
        }

        public void Update(int userId,
                           string name,
                           string description,
                           DateTime startDate,
                           DateTime endDate)
        {
            DomainExceptionValidation.When(userId < 0, "Invalid UserId value.");
            ValidateDomain(name, description, startDate, endDate);
            DateModification = DateTime.Now;
        }
        public void ValidateDomain(string name,
                                    string description,
                                    DateTime startDate,
                                    DateTime endDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required");
            DomainExceptionValidation.When(!(name.Length >= 3 && name.Length <= 200),
                                           "Invalid name, must be greater than or equal to 3 and less than 200 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid email. Name is required");
            DomainExceptionValidation.When(!(description.Length >= 10 && description.Length <= 1000),
                                            "Invalid email, must be greater than or equal to 10 and less than 1000 characters");
            DomainExceptionValidation.When(startDate > endDate,
                                           "StartDate cannot be greater than EndDate");
            DomainExceptionValidation.When(endDate < startDate,
                                           "EndDate cannot be less than StartDate");
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
