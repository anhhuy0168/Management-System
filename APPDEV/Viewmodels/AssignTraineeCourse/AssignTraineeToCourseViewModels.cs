using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.AssignTraineeCourse
{
    public class AssignTraineeToCourseViewModels
    {
        public int CourseId { get; set; }
        public string TraineeId { get; set; }
        public List<Course> Courses { get; set; }

        public List<Trainee> Trainees { get; set; }
    }
}