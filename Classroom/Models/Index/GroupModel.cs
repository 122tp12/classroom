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
        public void getTasks(int _idGroup, int _idUser)
        {
            using (classroomContext context = new classroomContext())
            {
                try
                {
                    Group group=new Group();
                    List<GroupUser> tmpList = context.GroupUsers.Where(n => n.IdGroup == _idGroup && n.IdUser == _idUser).ToList();
                    for (int i = 0; i < tmpList.Count; i++)
                    {
                        group = (context.Groups.Where(n => n.Id == tmpList[i].IdUser).First());
                    }
                    listTasks = context.Tasks.Where(n => n.IdGroup == group.Id).OrderBy(n => n.DatePublished).ToList();
                }
                catch (Exception ex)
                {
                    
                }
            }
            
        }
    }
}
