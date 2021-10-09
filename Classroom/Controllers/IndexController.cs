﻿using System;
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
            model.getTasks(1);//тут має бути id user, яка буде братись з сесії
            return View(model);
        }

        //всі завдання в групі
        [HttpGet]
        public IActionResult TasksInGroup(int _idGroup)
        {
            GroupModel model = new GroupModel();
            model.getTasks(1);//тут має бути id групи, яка буде братись get запроса
            return View(model);
        }

        //окремий таск
        [HttpGet]
        public IActionResult Task(int _idTask)
        {
            TaskModel model = new TaskModel();
            model.getTask(1);//тут має бути id таска, яка буде братись get запроса
            return View(model);
        }
    }
}
