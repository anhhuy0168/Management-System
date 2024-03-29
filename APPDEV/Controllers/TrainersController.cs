﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using APPDEV.Models;
using APPDEV.Utils;
using APPDEV.ViewModels;

namespace APPDEV.Controllers
{
    [Authorize(Roles = Role.Trainer)]
    public class TrainersController : Controller
    {
        // GET: Trainers
        private ApplicationDbContext _context;
        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Trainers
        [HttpGet]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var trainerInDb = _context.Trainers
                .SingleOrDefault(t => t.TrainerId == userId);
            return View(trainerInDb);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            var trainerInDb = _context.Trainers
                .SingleOrDefault(t => t.TrainerId == id);
            if (trainerInDb == null)
            {
                return HttpNotFound();
            }
            return View(trainerInDb);
        }

        [HttpPost]
        public ActionResult Edit(Trainer trainer)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == trainer.TrainerId);
            if (trainerInDb == null)
            {
                return HttpNotFound();
            }
            trainerInDb.FullName = trainer.FullName;
            trainerInDb.Age = trainer.Age;
            trainerInDb.Address = trainer.Address;
            trainerInDb.Specialty = trainer.Specialty;

            _context.SaveChanges();
            return RedirectToAction("index", "Trainers");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var trainerId = User.Identity.GetUserId();
            var category = _context.CourseCategories.ToList();
            var trainer = _context.Trainers.ToList();
            var course = _context.Courses
                .Include(t => t.CourseCategory)
                .ToList();
            var courses = _context.TrainersToCourses
                .Where(t => t.Trainer.TrainerId == trainerId)
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