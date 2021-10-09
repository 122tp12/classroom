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
        
        public TaskModel()
        {
            
        }
        public void getTask(int _idTask)
        {
            using (classroomContext context = new classroomContext())
            {
                task = context.Tasks.Where(n => n.Id == _idTask).First();
            }
        }
    }
}
