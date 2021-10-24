using Classroom.Models.UserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{
    public class UserProfileController : Controller
    {
        public IHttpContextAccessor accessor;
        private readonly classroomContext _context;
        //Just taking accessor for session
        public UserProfileController(IHttpContextAccessor _accessor, classroomContext context)
        {
            _context = context;
            accessor = _accessor;

        }
        private void startUp()
        {
            if (accessor.HttpContext.Session.GetInt32("user") == null)
            {
                ViewData["joined"] = false;
            }
            else
            {
                ViewData["joined"] = true;
            }
        }
        //інформація профіля
        public IActionResult Index()
        {
            startUp();
            ProfileModel model = new ProfileModel(_context);
            model.getUser(accessor.HttpContext.Session.GetInt32("user").Value);
            return View(model);
        }
        [HttpPost]
        public IActionResult update(string name, string description, string email, string password, IFormFile img)
        {
            ProfileModel model = new ProfileModel(_context);
            User u=_context.Users.Where(n => n.Id == accessor.HttpContext.Session.GetInt32("user").Value).FirstOrDefault();
            u.Name = name;
            u.Description = description;
            u.Email = email;
            u.Password = password;
            if (img != null)
            {
                try
                {
                    System.IO.File.Delete("~/profilePhoto/" + u.Id + ".jpg");
                }
                catch (Exception ex)
                {

                }
                model.SaveFile(img, u.Id);

            }
            model.SaveUser(u);
            return Redirect("~/UserProfile/");
        }
    }
}
