using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APPDEV.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("CourseCategory")]
        public int CategoryId { get; set; }

        public CourseCategory CourseCategory { get; set; }
    }
}