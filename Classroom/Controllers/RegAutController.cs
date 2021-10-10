using Classroom.Models.RegAut;
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
        private readonly classroomContext _context;
        public RegAutController(IHttpContextAccessor _accessor, classroomContext context)
        {
            _context = context;
            accessor = _accessor;
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationSave(String name, String password, String email, String img, String description)
        {
            User u = new User() { Name=name, Password=password, Email=email, ImgPath=img, Description=description};
            RegistrationModel model = new RegistrationModel(accessor, _context);
            model.saveUser(u);
            return Redirect("~/RegAut/Autoresation");
        }

        public IActionResult Autoresation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AutoresationSave(String Username, String Password)
        {
            AutoresationModel model=new AutoresationModel();
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
