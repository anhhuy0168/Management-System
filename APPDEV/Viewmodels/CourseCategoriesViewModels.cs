using APPDEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPDEV.ViewModels
{
    public class CourseCategoriesViewModels
    {
        public Course Courses { get; set; }

        public List<CourseCategory> CourseCategories { get; set; }
    }
}