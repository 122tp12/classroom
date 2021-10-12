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
        public List<Reaply> reaplies;
        classroomContext context;
        public TaskModel(classroomContext _context)
        {
            context = _context;
        }
        public void getTask(int _idTask)
        {
            
            task = context.Tasks.Where(n => n.Id == _idTask).First();
            
        }
        public void getMyReaplyes(int _idTask, int _idUser)
        {
            //context.Reaplies.Where(n => n);
        }
    }
}
