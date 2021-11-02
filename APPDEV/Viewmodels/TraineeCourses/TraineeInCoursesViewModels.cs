using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.TraineeCourses
{
    public class TraineeInCoursesViewModels
    {
        public Course Course { get; set; }

        public List<Trainee> Trainees { get; set; }
    }
}