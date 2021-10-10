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
        private readonly classroomContext _context;
        //Just taking accessor for session
        public IndexController(IHttpContextAccessor _accessor, classroomContext context)
        {
            _context = context;
            accessor = _accessor;

        }
        //сторінка з насками
        public IActionResult Index()
        {

            IndexModel model=new IndexModel(accessor, _context);
            try
            {
                model.getTasks(accessor.HttpContext.Session.GetInt32("user").Value);//тут має бути id user, яка буде братись з сесії
            }
            catch (Exception ex)
            {
                return Redirect("~/RegAut/Autoresation");//model.getTasks(1);//тимчасово, доки не ма перевірки на те чи залогінений юзер
            }
            return View(model);
        }

     

        //всі завдання в групі
        
        public IActionResult TasksInGroup(int id)
        {

            GroupModel model = new GroupModel(accessor, _context);
            try
            {
                model.getTasks(id, accessor.HttpContext.Session.GetInt32("user").Value);//тут має бути id групи, яка буде братись get запроса
            }
            catch (Exception ex)
            {
                return Redirect("~/RegAut/Autoresation");//model.getTasks(1);//тимчасово, доки не ма перевірки на те чи залогінений юзер
            }
            
            return View(model);
        }

        //окремий таск
        [HttpGet]
        public IActionResult Task(int id)
        {

            TaskModel model = new TaskModel(accessor, _context);
            model.getTask(id);//тут має бути id таска, яка буде братись get запроса

            return View(model);
        }
    }
}
