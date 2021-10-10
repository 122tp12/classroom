using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor accessor;
        private readonly classroomContext _context;

        public TaskModel(IHttpContextAccessor _accessor, classroomContext context)
        {
            accessor = _accessor;
            _context = context;
        }
        public void getTask(int _idTask)
        {
                task = _context.Tasks.Where(n => n.Id == _idTask).First();
        }
    }
}
