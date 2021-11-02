using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.TraineeCourses
{
    public class TraineeToCoursesViewModels
    {
        public int CourseId { get; set; }
        public int TraineeId { get; set; }
        public List<Course> Courses { get; set; }

        public List<Trainee> Trainees { get; set; }
    }
}