using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

        //сторінка з тасками
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

        public IActionResult DeleteTask(int id)
        {
            context.Tasks.Remove(context.Tasks.Where(n=>n.Id==id).FirstOrDefault());
            context.SaveChanges();
            return Redirect("~/");
        }
        public IActionResult DeleteGroup(int id)
        {
            context.Groups.Remove(context.Groups.Where(n => n.Id == id).FirstOrDefault());
            context.SaveChanges();
            return Redirect("~/");
        }

        //всі завдання в групі
        public IActionResult CreateTask(int id)
        {
            startUp();
            CreateTaskModel model = new CreateTaskModel(context);
            model.idGroup = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateTaskSave(int id, string description, string title, string type, IFormFile uploadedFile)
        {
            startUp();

            CreateTaskModel model = new CreateTaskModel(context);
            Task task = new Task();
            task.DatePublished = DateTime.Now;
            task.Description = description;
            task.Name = title;
            task.IdGroup = id;
            task.Type =type;

            int idFile=model.saveTask(task);
            model.SaveFile(uploadedFile, idFile);

            return Redirect("~/");
        }
        public IActionResult TasksInGroup(int id)
        {
            startUp();
            ViewData["currentId"] = id;

            GroupModel model = new GroupModel(context);
            bool owned=model.getTasks(id, accessor.HttpContext.Session.GetInt32("user").Value);//тут має бути id групи, яка буде братись get запроса
            ViewData["owned"] = owned;
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
            try
            {
                model.getMyReaplyes(id, accessor.HttpContext.Session.GetInt32("user").Value);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
            return View(model);
        }

        public IActionResult Reaply(int id)
        {
            startUp();

            ReaplyModel model = new ReaplyModel(context);
            model.currentId = id;
            try
            {
                model.userId= accessor.HttpContext.Session.GetInt32("user").Value;
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult ReaplySave(int id, string description, int userId, IFormFile uploadedFile)
        {
            startUp();
            
            ReaplyModel model = new ReaplyModel(context);

            int idFile=model.saveReaply(new Reaply() { Description = description, IdTask = id, IdUser = userId, FileName = uploadedFile.FileName });
            model.SaveFile(uploadedFile,idFile);
            
            return Redirect("~/Index/Task/" + id);
        }
        public FileResult DownloadFile(int id)
        {
            ReaplyModel model = new ReaplyModel(context);
            byte[] fileToRetrieve = model.getFile("wwwroot\\usersFiles\\"+id);
            Reaply r= context.Reaplies.Where(n => n.Id == id).FirstOrDefault();
            return File(fileToRetrieve, ReaplyModel.GetMimeType(r.FileName.Trim().Split('.').Last()), r.FileName.Trim()) ;
        }
        public FileResult DownloadTaskFile(int id)
        {
            TaskModel model = new TaskModel(context);
            byte[] fileToRetrieve = model.getFile("wwwroot\\tasksFiles\\" + id);
            Task r = context.Tasks.Where(n => n.Id == id).FirstOrDefault();
            return File(fileToRetrieve, TaskModel.GetMimeType(r.FileName.Trim().Split('.').Last()), r.FileName.Trim());
        }

        public IActionResult ReaplyDelete(int id)
        {
            ReaplyModel model = new ReaplyModel(context);

            int idTask = model.deleteReaply(id);

            return Redirect("~/Index/Task/"+idTask);
        }
    }
}
