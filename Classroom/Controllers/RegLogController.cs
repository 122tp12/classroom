using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{
    //контролер для регістрації, авторизації
    public class RegLogController : Controller
    {
        IHttpContextAccessor accessor;
        public RegLogController(IHttpContextAccessor _accessor)
        {
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
        
    }
}
