using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APPDEV.Models
{
    public class Trainee
    {
        [Key]
        [ForeignKey("User")]
        //khoa ngoai vs bang user
        public string TraineeId { get; set; }

        public ApplicationUser User { get; set; }

        //for validation
        [Required]

        public string FullName { get; set; }

        [Required]

        public int Age { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]

        public string Education { get; set; }
    }
}