using APPDEV.Models;
using APPDEV.Utils;
using APPDEV.Viewmodels.AssignTrainerCourse;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace APPDEV.Controllers
{
    public class AssignTrainertoCoursesController : Controller
    {
        private ApplicationDbContext _context;
        public AssignTrainertoCoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: AssignTrainertoCourses
        [Authorize(Roles = "staff, trainer")]
        public ActionResult Index(string searchString)
        {
            var courses = _context.Courses.Include(t => t.CourseCategory).ToList();
            var trainer = _context.TrainersToCourses.ToList();

            List<AssignTrainerInCourseViewModels> viewModel = _context.TrainersToCourses
                .GroupBy(i => i.Course)
                .Select(res => new AssignTrainerInCourseViewModels
                {
                    Course = res.Key,
                    Trainers = res.Select(u => u.Trainer).ToList()
                })
                .ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                viewModel = viewModel
                    .Where(t => t.Course.Name.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
            return View(viewModel);
        }
    }
}