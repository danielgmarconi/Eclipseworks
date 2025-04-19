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
        public PriorityStatus Priority { get; private set; } = PriorityStatus.low;
        public ProjectTaskStatus Status { get; private set; } = ProjectTaskStatus.none;
        public Int16 TimeHoursTask { get; private set; }
        public ProjectTask(string name,
                           string description,
                           PriorityStatus priority,
                           Int16 timeHoursTask)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required");
            DomainExceptionValidation.When(!(name.Length >= 3 && name.Length <= 200),
                                           "Invalid name, must be greater than or equal to 3 and less than 200 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid email. Name is required");
            DomainExceptionValidation.When(!(description.Length >= 10 && description.Length <= 1000),
                                           "Invalid email, must be greater than or equal to 10 and less than 1000 characters");
            DomainExceptionValidation.When(timeHoursTask <= 0,
                                           "TimeHoursTask must be greater than zero");
            Name = name;
            Description = description;
            Priority = priority;
            Status = ProjectTaskStatus.none;
            TimeHoursTask = timeHoursTask;
        }
        public void Update(string name,
                           string description,
                           PriorityStatus priority,
                           Int16 timeHoursTask)
        {
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
            DomainExceptionValidation.When(StartDate != null && priority != Priority,
                                           "The priority cannot be changed, the task has already been started.");
            DomainExceptionValidation.When(StartDate != null && timeHoursTask != TimeHoursTask,
                                           "The amount of time cannot be changed, the task has already been started.");
            Name = name;
            Description = description;
            Priority = priority;
            Status = ProjectTaskStatus.none;
            TimeHoursTask = timeHoursTask;
        }
        public void StatusUpdate(ProjectTaskStatus status)
        {
            DomainExceptionValidation.When(StartDate != null && status == ProjectTaskStatus.none,
                               "Cannot change task to none because it has already been started");
            Status = status;
        }

    }
}
