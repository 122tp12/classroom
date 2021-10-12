using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.GroupC
{
    public class JoinModel: PageModel
    {
        classroomContext context;
        public JoinModel(classroomContext _context)
        {
            context = _context;
        }
        public bool saveGroupUserRelationship(int _userId, int _groupId, string _password)
        {
            Group g=context.Groups.Where(n => n.Id == _groupId).FirstOrDefault();
            if (g.Password.Trim() == _password)
            {
                context.GroupUsers.Add(new GroupUser() {IdGroup=_groupId, IdUser=_userId });
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
