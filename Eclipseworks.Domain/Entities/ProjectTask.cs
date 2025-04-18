using Eclipseworks.Domain.Enums;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Domain.Entities
{
    public sealed class ProjectTask : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<ProjectTaskComment>? ProjectTaskComments { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public PriorityStatus Priority { get;private set; }
        public ProjectTaskStatus Status { get; private set; }
        public Int16 TimeHoursTask { get; private set; }
        public ProjectTask(string name,
                           string description,
                           DateTime? startDate,
                           DateTime? endDate,
                           PriorityStatus priority,
                           ProjectTaskStatus status,
                           Int16 timeHoursTask)
        {
            //DomainExceptionValidation.When(userid <= 0,
            //                               "userid is required");
            //DomainExceptionValidation.When(projectId <= 0,
                                           //"projectId is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required");
            DomainExceptionValidation.When(!(name.Length >= 3 && name.Length <= 200),
                                           "Invalid name, must be greater than or equal to 3 and less than 200 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid email. Name is required");
            DomainExceptionValidation.When(!(description.Length >= 10 && description.Length <= 1000),
                                           "Invalid email, must be greater than or equal to 10 and less than 1000 characters");
            DomainExceptionValidation.When(TimeHoursTask <= 0,
                                           "TimeHoursTask must be greater than zero");
            //UserId = userid;
            //ProjectId = projectId;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Priority = priority;
            Status = status;
            TimeHoursTask = timeHoursTask;
        }
    }
}
