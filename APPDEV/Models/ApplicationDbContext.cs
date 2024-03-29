﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace APPDEV.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           // : base("DefaultConnection", throwIfV1Schema: false)
           : base("AzureDeployApp", throwIfV1Schema: false)
        {
        }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<TraineesToCourses> TraineesToCourses { get; set; }
        public DbSet<TrainersToCourses> TrainersToCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}