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
        public GroupModel()
        {
         
        }
        public void getTasks(int _idGroup)
        {
            using (classroomContext context = new classroomContext())
            {
                listTasks = context.Tasks.Where(n => n.IdGroup == _idGroup).OrderBy(n => n.DatePublished).ToList();
            }
        }
    }
}
