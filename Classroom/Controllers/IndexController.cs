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
       
        public IActionResult Index()
        {
            IndexModel model=new IndexModel(accessor);

            return View(model);
        }
    }
}
