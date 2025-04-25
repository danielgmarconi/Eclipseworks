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
        [DisplayName("Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [DisplayName("UserId")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3, ErrorMessage = "The Name must be at least 3 characters long.")]
        [MaxLength(200, ErrorMessage = "The name can have a maximum of 200 characters.")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Description is required")]
        [MinLength(3, ErrorMessage = "The Description must be at least 3 characters long.")]
        [MaxLength(1000, ErrorMessage = "The Description can have a maximum of 1000 characters.")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("StartDate")]
        public DateTime StartDate { get; set; }
        [DisplayName("EndDate")]
        public DateTime EndDate { get; set; }
    }
}
