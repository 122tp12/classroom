using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.RegAut
{
    public class AutoresationModel : PageModel
    {
        public User user;
        classroomContext context;
        public AutoresationModel(classroomContext _context)
        {
            context = _context;
            user = null;
        }
        public void getUser(String nam, String pas)
        {
            user = context.Users.Where(n => n.Name == nam &&n.Password==pas).First();
            
        }
    }
}
