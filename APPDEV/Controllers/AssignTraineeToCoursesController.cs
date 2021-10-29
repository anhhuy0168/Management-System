using APPDEV.Models;
using APPDEV.Utils;
using APPDEV.Viewmodels.AssignTraineeCourse;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace APPDEV.Controllers
{
    public class AssignTraineeToCoursesController : Controller
    {
        private ApplicationDbContext _context;
        public AssignTraineeToCoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: AssignTraineeToCourses
        [Authorize(Roles = "staff, trainer")]
        public ActionResult Index(string searchString)
        {
            var courses = _context.Courses.Include(t => t.CourseCategory).ToList();
            var trainee = _context.TraineesToCourses.ToList();
            List<AssignTraineeInCourseViewModels> viewModel = _context.TraineesToCourses
                .GroupBy(i => i.Course)
                .Select(res => new AssignTraineeInCourseViewModels
                {
                    Course = res.Key,
                    Trainees = res.Select(u => u.Trainee).ToList()
                })
                .ToList();
            if(!string.IsNullOrEmpty(searchString))
            {
                viewModel = viewModel
                    .Where(t => t.Course.Name.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
            return View(viewModel);
        }
        [Authorize(Roles = "staff")]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new AssignTraineeToCourseViewModels
            {
                Courses = _context.Courses.ToList(),
                Trainees = _context.Trainees.ToList()
            };
            return View(viewModel);
        }
    }
}