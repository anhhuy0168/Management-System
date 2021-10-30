using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.AssignTrainerCourse
{
    public class AssignTrainerInCourseViewModels
    {
        public Course Course { get; set; }

        public List<Trainer> Trainers { get; set; }
    }
}