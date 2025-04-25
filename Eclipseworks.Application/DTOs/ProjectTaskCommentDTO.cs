using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipseworks.Application.DTOs
{
    public class ProjectTaskCommentDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The UserId is required")]
        [DisplayName("UserId")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The ProjectTaskId is required")]
        [DisplayName("ProjectTaskId")]
        public int ProjectTaskId { get; set; }
        [Required(ErrorMessage = "The Comment is required")]
        [MinLength(3, ErrorMessage = "The Comment must be at least 3 characters long.")]
        [MaxLength(1000, ErrorMessage = "The Comment can have a maximum of 1000 characters.")]
        [DisplayName("Comment")]
        public string Comment { get; set; }
    }
}
