using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Domain.Entities
{
    public sealed class ProjectTaskComment : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public string Comment { get; private set; }
        public ProjectTaskComment(int userId, 
                                  int projectTaskId, 
                                  string comment)
        {
            UserId = userId;
            ProjectTaskId = projectTaskId;
            Comment = comment;
        }
        public void Update(string comment)
        {

            Comment = comment;
        }
        public void ValidateDomain(int userId,
                                  int projectTaskId,
                                  string comment)
        {
            DomainExceptionValidation.When(userId < 0, "Invalid UserId value.");
            DomainExceptionValidation.When(projectTaskId < 0, "Invalid UserId value.");
            DomainExceptionValidation.When(!(comment.Length >= 10 && comment.Length <= 1000),
                                           "Invalid description, must be greater than or equal to 10 and less than 1000 characters");
        }
    }
}
