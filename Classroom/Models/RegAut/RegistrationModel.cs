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
        public void saveUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
