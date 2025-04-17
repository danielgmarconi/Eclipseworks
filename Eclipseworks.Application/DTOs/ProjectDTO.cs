using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Application.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3, ErrorMessage = "The Name must be at least 3 characters long.")]
        [MaxLength(200, ErrorMessage = "The name can have a maximum of 200 characters.")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3, ErrorMessage = "The Name must be at least 3 characters long.")]
        [MaxLength(1000, ErrorMessage = "The name can have a maximum of 1000 characters.")]
        [DisplayName("Description")]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
