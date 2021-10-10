using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.RegAut
{
    public class RegistrationModel : PageModel
    {
        public RegistrationModel()
        {
            
        }
        public void saveUser(User user)
        {
            using (classroomContext context = new classroomContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
