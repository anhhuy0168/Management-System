
using APPDEV.Models;
using APPDEV.Utils;
using APPDEV.Viewmodels.TraineeCourses;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace APPDEV.Controllers
{
    public class AssignTraineeCoursesController : Controller
    {
        private ApplicationDbContext _context;
        public AssignTraineeCoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: AssignTraineeCourses
        [HttpGet]
        public ActionResult GetTrainees(string searchString)
        {
            var courses = _context.Courses.Include(t => t.CourseCategory).ToList();
            var trainees = _context.TraineesToCourses.ToList();

            List<TraineeInCoursesViewModels> viewModel = _context.TraineesToCourses
                .GroupBy(i => i.Course)
                .Select(res => new TraineeInCoursesViewModels
                {
                    Course = res.Key,
                    Trainees = res.Select(u => u.Trainee).ToList(),
                })
                .ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                viewModel = viewModel
                   .Where(t => t.Course.Name
                   .ToLower()
                   .Contains(searchString.ToLower()))
                   .ToList();
            }

            return View(viewModel);
        }
        [HttpGet]
        public ActionResult AddTrainee()
        {
            var viewModel = new TraineeToCoursesViewModels
            {
                Courses = _context.Courses.ToList(),
                Trainees = _context.Trainees.ToList(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddTrainee(TraineeToCoursesViewModels model)
        {
            //get view if model is invalid
            var getViewModel = new TraineesToCourses
            {
                CourseId = model.CourseId,
                TraineeId = model.TraineeId
            };
            List<TraineesToCourses> traineesCourses = _context.TraineesToCourses.ToList();
            bool alreadyExist = traineesCourses.Any(item => item.CourseId == model.CourseId && item.TraineeId == model.TraineeId);
            if (alreadyExist == true)
            {
                ModelState.AddModelError("", "Trainee is already assignned this Course");
                return RedirectToAction("GetTrainees", "AssignTraineeCourses");
            }
            _context.TraineesToCourses.Add(getViewModel);
            _context.SaveChanges();

            return RedirectToAction("GetTrainees", "AssignTraineeCourses"); 

        }
        [HttpGet]
        public ActionResult RemoveTrainee()
        {
            var getTrainee = _context.TraineesToCourses.Select(t => t.Trainee)
                .Distinct()
                .ToList();
            var getCourse = _context.TraineesToCourses.Select(t => t.Course)
                .Distinct()
                .ToList();
            var viewModel = new TraineeToCoursesViewModels
            {
                Courses = getCourse,
                Trainees = getTrainee,
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult RemoveTrainee(TraineeToCoursesViewModels models)
        {
            var getTrainee = _context.TraineesToCourses
                .SingleOrDefault(c => c.CourseId == models.CourseId && c.TraineeId == models.TraineeId);
            if (getTrainee == null)
            {
                return RedirectToAction("GetTrainees", "AssignTraineeCourses");
            }

            _context.TraineesToCourses.Remove(getTrainee);
            _context.SaveChanges();
            return RedirectToAction("GetTrainees", "AssignTraineeCourses");
        }
    }
}