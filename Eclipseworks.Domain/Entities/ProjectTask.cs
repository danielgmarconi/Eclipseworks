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
        public ProjectTask(int userid,
                           int projectId,
                           string name,
                           string description,
                           DateTime? startDate,
                           DateTime? endDate,
                           PriorityStatus priority,
                           ProjectTaskStatus status,
                           Int16 timeHoursTask)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required");
            DomainExceptionValidation.When(!(name.Length >= 3 && name.Length <= 200),
                                           "Invalid name, must be greater than or equal to 3 and less than 200 characters");

        }
    }
}
