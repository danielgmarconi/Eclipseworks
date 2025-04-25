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

        public ProjectTaskComment(string comment)
        {
            Comment = comment;
        }
        public void Update(string comment)
        {
            DomainExceptionValidation.When(Id <= 0, "Invalid Id value.");
            Comment = comment;
            DateModification = DateTime.Now;
            ValidateDomain();
        }       
        public void ValidateDomain()
        {
            DomainExceptionValidation.When(UserId <= 0, "Invalid UserId value.");
            DomainExceptionValidation.When(ProjectTaskId < 0, "Invalid UserId value.");
            DomainExceptionValidation.When(!(Comment.Length >= 10 && Comment.Length <= 1000),
                                           "Invalid description, must be greater than or equal to 10 and less than 1000 characters");
        }
    }
}
