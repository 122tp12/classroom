using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{
    public class RegLogController : Controller
    {
        IHttpContextAccessor accessor;
        public RegLogController(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
