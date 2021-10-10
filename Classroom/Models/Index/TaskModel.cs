using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.Index
{
    public class TaskModel : PageModel
    {
        public Classroom.Task task;
        classroomContext context;
        public TaskModel(classroomContext _context)
        {
            context = _context;
        }
        public void getTask(int _idTask)
        {
            
            task = context.Tasks.Where(n => n.Id == _idTask).First();
            
        }
    }
}
