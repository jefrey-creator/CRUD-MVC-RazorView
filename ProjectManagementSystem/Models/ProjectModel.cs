using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
	public class ProjectModel
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(30)]
        public String ProjectName { get; set; }
        [Required]
        [MaxLength(15)]
        public String ProjectCost { get; set; }
        [Required]
        public int ProjectStatus { get; set; }
    }
}