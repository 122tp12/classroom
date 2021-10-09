using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.Models.Index;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Classroom.Controllers
{
 

    public class IndexController : Controller
    {
        public IHttpContextAccessor accessor;
        //Just taking accessor for session
        public IndexController(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;

        }
        //сторінка з насками
        public IActionResult Index()
        {
            IndexModel model=new IndexModel(accessor);

            return View(model);
        }
        //окремий таск
        public IActionResult Task()
        {
            
            return View();
        }
        //всі завдання які треба зробити
        public IActionResult Tasks()
        {

            return View();
        }
    }
}
