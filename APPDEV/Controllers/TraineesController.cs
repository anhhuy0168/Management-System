﻿using APPDEV.Models;
using APPDEV.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APPDEV.Controllers
{
    public class TraineesController : Controller
    {
        private ApplicationDbContext _context;
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Trainees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var traineeInDb = _context.Trainees
                .SingleOrDefault(t => t.TraineeId == userId);
            return View(traineeInDb);
        }
        [HttpGet]
        public ActionResult Courses()
        {
            var userId = User.Identity.GetUserId();
            var category = _context.CourseCategories.ToList();

            var courses = _context.TraineesToCourses
                .Where(t => t.Trainee.TraineeId == userId)
                .Select(t => t.Course)
                .ToList();
            return View(courses);
        }
        [HttpGet]
        public ActionResult CourseTrainees(int id)
        {
            var user = _context.Users.ToList();
            var traineesCourse = _context.TraineesToCourses
                .Where(t => t.CourseId == id)
                .Select(t => t.Trainee)
                .ToList();
            return View(traineesCourse);
        }
    }
}