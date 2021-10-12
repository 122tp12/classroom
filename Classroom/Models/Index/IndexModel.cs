using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.Index
{
    public class IndexModel : PageModel
    {
        public List<Classroom.Group> listGroups;
        public List<Group> listMyGroups;
        IHttpContextAccessor accessor;
        classroomContext context;
        public IndexModel(IHttpContextAccessor _accessor, classroomContext _context)
        {
            context = _context;
            accessor = _accessor;
        }
        public void getTasks(int _idUser)
        {
            
            listGroups = new List<Classroom.Group>();
            List<GroupUser> tmpList = context.GroupUsers.Where(n=>n.IdUser==_idUser).ToList();
            for(int i=0;i<tmpList.Count ;i++ )
            {
                listGroups.Add(context.Groups.Where(n=>n.Id== tmpList[i].IdGroup).First());
            }

            listMyGroups = context.Groups.Where(n=>n.IdOwner==_idUser).ToList();
        }
        
    }
}
