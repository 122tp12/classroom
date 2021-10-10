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
        public AutoresationModel()
        {
            user = null;
        }
        public void getUser(String nam, String pas)
        {
            using (classroomContext context = new classroomContext())
            {
                user = context.Users.Where(n => n.Name == nam &&n.Password==pas).First();
            }
        }
    }
}
