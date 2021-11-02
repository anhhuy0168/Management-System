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
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Education { get; set; }

        [ForeignKey("User")]
        public String TraineeId { get; set; }
        public ApplicationUser User { get; set; }
    }
}