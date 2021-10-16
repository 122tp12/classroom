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
        //інформація профіля
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
