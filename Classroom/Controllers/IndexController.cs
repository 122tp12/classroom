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
        public classroomContext context;
        //Just taking accessor for session
        public IndexController(IHttpContextAccessor _accessor, classroomContext _context)
        {
            
            context = _context;
            accessor = _accessor;
        }

        private void startUp()
        {
            if (accessor.HttpContext.Session.GetInt32("user")==null)
            {
                ViewData["joined"] = false;
            }
            else
            {
                ViewData["joined"] = true;
            }
        }

        //сторінка з насками
        public IActionResult Index()
        {
            startUp();
            IndexModel model=new IndexModel(accessor, context);
            try
            {
                model.getTasks(accessor.HttpContext.Session.GetInt32("user").Value);//тут має бути id user, яка буде братись з сесії
            }
            catch (Exception ex)
            {
                //return Redirect("~/RegAut/Autoresation");//model.getTasks(1);//тимчасово, доки не ма перевірки на те чи залогінений юзер
            }
            return View(model);
        }

     

        //всі завдання в групі
        
        public IActionResult TasksInGroup(int id)
        {
            startUp();
            ViewData["currentId"] = id;

            GroupModel model = new GroupModel(context);
            try
            {
                model.getTasks(id, accessor.HttpContext.Session.GetInt32("user").Value);//тут має бути id групи, яка буде братись get запроса
            }
            catch (Exception ex)
            {
                //return Redirect("~/RegAut/Autoresation");//model.getTasks(1);//тимчасово, доки не ма перевірки на те чи залогінений юзер
            }
            
            return View(model);
        }
        public IActionResult PeopleInGroup(int id)
        {
            startUp();
            ViewData["currentId"] = id;

            GroupModel model = new GroupModel(context);
            try
            {
                model.getPeoples(id);//тут має бути id групи, яка буде братись get запроса
            }
            catch (Exception ex)
            {
                //return Redirect("~/RegAut/Autoresation");//model.getTasks(1);//тимчасово, доки не ма перевірки на те чи залогінений юзер
            }

            return View(model);
        }
        

        //окремий таск
        [HttpGet]
        public IActionResult Task(int id)
        {
            startUp();
            TaskModel model = new TaskModel(context);
            model.getTask(id);//тут має бути id таска, яка буде братись get запроса
            return View(model);
        }

        public IActionResult Reaply(int id)
        {
            startUp();

            ReaplyModel model = new ReaplyModel(context);
            model.currentId = id;

            return View(model);
        }
        [HttpPost]
        public IActionResult ReaplySave(int id, string description)
        {
            startUp();

            ReaplyModel model = new ReaplyModel(context);
            model.saveReaply(new Reaply() { description = description, IdTask = id });

            return Redirect("~/Index/Task/" + id);
        }
    }
}
