using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.AssignTrainerCourse
{
    public class AssignTrainerToCourseViewModels
    {
        public int CourseId { get; set; }
        public string TrainerId { get; set; }

        public List<Course> Courses { get; set; }
        public List<Trainer> Trainers { get; set; }
    }
}