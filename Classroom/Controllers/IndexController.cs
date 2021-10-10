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
            try
            {
                model.getTasks(accessor.HttpContext.Session.GetInt32("user").Value);//тут має бути id user, яка буде братись з сесії
            }
            catch (Exception ex)
            {
                model.getTasks(1);//тимчасово, доки не ма перевірки на те чи залогінений юзер
            }
            return View(model);
        }

     

        //всі завдання в групі
        
        public IActionResult TasksInGroup(int id)
        {
            GroupModel model = new GroupModel();
            model.getTasks(id);//тут має бути id групи, яка буде братись get запроса
            return View(model);
        }

        //окремий таск
        [HttpGet]
        public IActionResult Task(int id)
        {
            TaskModel model = new TaskModel();
            model.getTask(id);//тут має бути id таска, яка буде братись get запроса
            return View(model);
        }
    }
}
