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
        [Authorize(Roles = "staff")]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new AssignTrainerToCourseViewModels
            {
                Courses = _context.Courses.ToList(),
                Trainers = _context.Trainers.ToList(),
            };
            return View(viewModel);
        }
        [Authorize(Roles = "staff")]
        [HttpPost]
        public ActionResult Create(AssignTrainerToCourseViewModels model)
        {
            //goi lai index
            var getViewModel = new AssignTrainerToCourseViewModels
            {
                Courses = _context.Courses.ToList(),
                Trainers = _context.Trainers.ToList(),
            };

            if (!ModelState.IsValid)
            {
                return View(getViewModel);
            }

            var viewModel = new AssignTrainerToCourse
            {
                CourseId = model.CourseId,
                TrainerId = model.TrainerId
            };

            //check is exist
            List<AssignTrainerToCourse> traineerstoCourses = _context.TrainersToCourses.ToList();
            bool alreadyExist = traineerstoCourses
                .Any(item => item.CourseId == model.CourseId && item.TrainerId == model.TrainerId);
            if (alreadyExist == true)
            {
                ModelState.AddModelError("", "Trainer is Already Exist");
                return View(getViewModel);
            }

            _context.TrainersToCourses.Add(viewModel);
            _context.SaveChanges();
            return RedirectToAction("Index", "AssignTrainerToCourses");
        }
        [Authorize(Roles = "staff")]
        [HttpGet]
        public ActionResult Remove()
        {
            var getTrainer = _context.TrainersToCourses.Select(t => t.Trainer)
                .Distinct()
                .ToList();
            var getCourse = _context.TrainersToCourses.Select(t => t.Course)
                .Distinct()
                .ToList();
            var viewModel = new AssignTrainerToCourseViewModels
            {
                Trainers = getTrainer,
                Courses = getCourse
            };
            return View(viewModel);
        }
        [Authorize(Roles = "staff")]
        [HttpPost]
        public ActionResult Remove(AssignTrainerToCourseViewModels model)
        {
            var getTrainer = _context.TrainersToCourses
                .SingleOrDefault(c => c.CourseId == model.CourseId && c.TrainerId == model.TrainerId);
            if(getTrainer == null)
            {
                return RedirectToAction("Index", "AssignTrainertoCourses");
            }
            _context.TrainersToCourses.Remove(getTrainer);
            _context.SaveChanges();
            return RedirectToAction("Index", "AssignTrainertoCourses");
        }    
    }
}