using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.Viewmodels.TrainerCourses
{
    public class TrainersInCoursesViewModels
    {
        public Course Course { get; set; }

        public List<Trainer> Trainers { get; set; }
    }
}