using APPDEV.Models;
using APPDEV.Utils;
using APPDEV.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APPDEV.Controllers
{
    public class AdminsController : Controller
    {
        //tao ket noi
        private ApplicationDbContext _context;

        private ApplicationUserManager _userManager;

        public AdminsController()
        {
            _context = new ApplicationDbContext();
        }

        public AdminsController(ApplicationUserManager userManager)
        {
            _context = new ApplicationDbContext();
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult IndexStaff()
        {
            var staff = _context.Staffs.ToList();
            var user = _context.Users.ToList();

            return View(staff);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateStaffAccount()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> CreateStaffAccount(CreateStaffViewModels viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { UserName = viewModel.RegisterViewModels.Email, Email = viewModel.RegisterViewModels.Email };
                var result = await UserManager.CreateAsync(user, viewModel.RegisterViewModels.Password);
                var staffId = user.Id;
                var newStaff = new Staff()
                {
                    StaffId = staffId,
                    FullName = viewModel.Staffs.FullName,
                    Age = viewModel.Staffs.Age,
                    Address = viewModel.Staffs.Address,
                };

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "staff");
                    _context.Staffs.Add(newStaff);
                    _context.SaveChanges();
                }
                AddErrors(result);
            }

            return RedirectToAction("IndexStaff", "Admins");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

       



        /// <summary>
        /// FOR TRAINER
        /// </summary>

        [Authorize(Roles = "admin ")]
        [HttpGet]
        public ActionResult IndexTrainer()
        {
            var trainer = _context.Trainers.ToList();
            var user = _context.Users.ToList();

            return View(trainer);
        }

       
    }
}