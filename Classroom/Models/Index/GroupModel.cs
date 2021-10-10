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
        public void getTasks(int _idGroup, int _idUser)
        {

                try
                {
                    Group group=new Group();
                    List<GroupUser> tmpList = _context.GroupUsers.Where(n => n.IdGroup == _idGroup && n.IdUser == _idUser).ToList();
                    for (int i = 0; i < tmpList.Count; i++)
                    {
                        group = (_context.Groups.Where(n => n.Id == tmpList[i].IdUser).First());
                    }
                    listTasks = _context.Tasks.Where(n => n.IdGroup == group.Id).OrderBy(n => n.DatePublished).ToList();
                }
                catch (Exception ex)
                {
                    
                }
        }
    }
}
