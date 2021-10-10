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
        
        public IActionResult Autoresation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AutoresationSave(int? id)
        {
            accessor.HttpContext.Session.SetInt32("user", id.Value);
            return Redirect("~/");
        }
        

    }
}
