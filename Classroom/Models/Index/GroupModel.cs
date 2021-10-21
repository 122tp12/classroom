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
        public List<Task> listTasks;
        public List<User> members;
        public User owner;
        public int groupId;
        classroomContext context;
        public GroupModel(classroomContext _context, int _gI)
        {
            groupId = _gI;
            context = _context;

        }
        public bool getTasks(int _idGroup, int _idUser)
        {
            
                try
                {
                    /*Group group=new Group();
                    List<GroupUser> tmpList = context.GroupUsers.Where(n => n.IdGroup == _idGroup && n.IdUser == _idUser).ToList();
                    for (int i = 0; i < tmpList.Count; i++)
                    {
                        group = (context.Groups.Where(n => n.Id == tmpList[i].IdUser).First());
                    }*/
                    listTasks = context.Tasks.Where(n => n.IdGroup == _idGroup/*group.Id*/).OrderBy(n => n.DatePublished).ToList();

                }
                catch (Exception ex)
                {
                    
                }
            if (context.Groups.Where(n => n.Id == _idGroup).First().IdOwner == _idUser)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool getPeoples(int _idGroup, int _idUser)
        {
            try
            {
                List<User> users=new List<User>();
                List<GroupUser> l=context.GroupUsers.Where(n => n.IdGroup == _idGroup).ToList();
                for(int i=0;i<l.Count ;i++ )
                {
                    users.Add(context.Users.Where(n=>n.Id== l[i].IdUser).FirstOrDefault());
                }
                members = users;
                owner = context.Users.Where(n=>n.Id==(context.Groups.Where(n=>n.Id==_idGroup).FirstOrDefault().IdOwner)).FirstOrDefault();
            }
            catch(Exception ex)
            {

            }
            if (context.Groups.Where(n => n.Id == _idGroup).First().IdOwner == _idUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
