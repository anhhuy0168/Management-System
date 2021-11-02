using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.TrainerCourses
{
    public class TrainersToCoursesViewModels
    {
        public int CourseId { get; set; }
        public int TrainerId { get; set; }

        public List<Course> Courses { get; set; }
        public List<Trainer> Trainers { get; set; }
    }
}