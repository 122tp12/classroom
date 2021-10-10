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
        private IHttpContextAccessor accessor;
        private readonly classroomContext _context;
        public IndexModel(IHttpContextAccessor _accessor, classroomContext context)
        {
            accessor = _accessor;
            _context = context;
        }
        public void getTasks(int _idUser)
        {
                listGroups = new List<Group>();
                List<GroupUser> tmpList = _context.GroupUsers.Where(n=>n.IdUser==_idUser).ToList();
                for(int i=0;i<tmpList.Count ;i++ )
                {
                    listGroups.Add(_context.Groups.Where(n=>n.Id== tmpList[i].IdGroup).First());
                }
        }
        
    }
}
