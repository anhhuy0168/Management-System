using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.ViewModels
{
    public class CreateTraineeViewModels
    {
        public RegisterViewModel RegisterViewModels { get; set; }

        public Trainee Trainees { get; set; }

        public ApplicationUser TraineeUsers { get; set; }
    }
}