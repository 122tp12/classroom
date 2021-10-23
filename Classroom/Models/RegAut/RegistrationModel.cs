using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.RegAut
{
    public class RegistrationModel : PageModel
    {

        classroomContext context;
        public RegistrationModel(classroomContext _context)
        {
            context = _context;
        }
        public int saveUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            User u = context.Users.OrderBy(n => n.Id).Last();
            return u.Id;
        }
    }
}
