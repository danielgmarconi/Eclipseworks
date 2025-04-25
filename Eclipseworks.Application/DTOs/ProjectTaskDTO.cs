using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Application.DTOs
{
   public class ProjectTaskDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("UserId")]
        public int UserId { get; set; }
        [DisplayName("ProjectId")]
        public int ProjectId { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("StartDate")]
        public DateTime? StartDate { get; set; }
        [DisplayName("EndDate")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Priority")]
        public string Priority { get; set; }
        [DisplayName("Status")]
        public string? Status { get; set; }
        [DisplayName("TimeHoursTask")]
        public Int16 TimeHoursTask { get; set; }
    }
}
