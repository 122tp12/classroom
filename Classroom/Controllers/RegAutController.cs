using Classroom.Models.RegAut;
using Classroom.Models.UserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{
    //контролер для регістрації, авторизації
    public class RegAutController : Controller
    {
        IHttpContextAccessor accessor;
        classroomContext context;
        public RegAutController(IHttpContextAccessor _accessor, classroomContext _context)
        {
            context = _context;
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
        public IActionResult Registration()
        {
            startUp();
            return View();
        }
        public IActionResult Exit()
        {
            accessor.HttpContext.Session.Remove("user");
            return Redirect("~/");
        }
        [HttpPost]
        public IActionResult RegistrationSave(String name, String password, String email, String description, IFormFile file)
        {
            User u = new User() { Name=name, Password=password, Email=email, Description=description};
            
            RegistrationModel model = new RegistrationModel(context);

            int id=model.saveUser(u);

            if (file != null)
            {
                ProfileModel uploadModel = new ProfileModel(context);
                uploadModel.SaveFile(file, id);
            }

            return Redirect("~/RegAut/Autoresation");
        }

        public IActionResult Autoresation()
        {
            startUp();
            return View();
        }
        [HttpPost]
        public IActionResult AutoresationSave(String Username, String Password)
        {
            AutoresationModel model=new AutoresationModel(context);
            try
            {
                model.getUser(Username, Password);
            }
            catch (Exception ex)
            {
                return Redirect("~/RegAut/Autoresation");
            }
            if (model.user==null)
            {
                return Redirect("~/RegAut/Autoresation");
            }
            else
            {
                accessor.HttpContext.Session.SetInt32("user", model.user.Id);
                return Redirect("~/");
            }
            
        }
        

    }
}
