
using Classroom.Models.GroupC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{ 
    public class GroupCController : Controller
    {
        IHttpContextAccessor accessor;
        classroomContext context;
        public GroupCController(IHttpContextAccessor _accessor, classroomContext _context)
        {
            accessor = _accessor;
            context = _context;
        }
        private void startUp()
        {
            if (accessor.HttpContext.Session.GetInt32("user") == null)
            {
                ViewData["joined"] = false;
            }
            else
            {
                ViewData["joined"] = true;
            }
        }

        public IActionResult Create()
        {
            startUp();

            return View();
        }
        [HttpPost]
        public IActionResult CreateConfirm(string name, string description, string password)
        {
            CreateGroupModel model = new CreateGroupModel(context);
            try
            {
                model.saveGroupUserRelationship(accessor.HttpContext.Session.GetInt32("user").Value, name, description, password);
            }
            catch(Exception ex)
            {
                return Redirect("~/GroupC/Create");
            }
            return Redirect("~/");
        }
        public IActionResult Join()
        {
            startUp();

            return View();
        }
        [HttpPost]
        public IActionResult JoinConfirm(int id, string password)
        {
            JoinModel model = new JoinModel(context);
            bool saved;
            try
            {
                saved=model.saveGroupUserRelationship(accessor.HttpContext.Session.GetInt32("user").Value, id, password);
            }
            catch (Exception ex)
            {
                return Redirect("~/GroupC/Join");
            }
            if (saved)
            {
                return Redirect("~/");
            }
            else
            {
                return Redirect("~/GroupC/Join");
            }
        }
    }
}
