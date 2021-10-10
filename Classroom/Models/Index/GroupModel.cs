using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.Index
{
    public class GroupModel: PageModel
    {
        public List<Classroom.Task> listTasks;
        private IHttpContextAccessor accessor;
        private readonly classroomContext _context;
        public GroupModel(IHttpContextAccessor _accessor,classroomContext context)
        {
            accessor = _accessor;
            _context = context;
        }
        public void getTasks(int _idGroup)
        {
                listTasks = _context.Tasks.Where(n => n.IdGroup == _idGroup).OrderBy(n => n.DatePublished).ToList();
        }
    }
}
