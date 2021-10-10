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
        private IHttpContextAccessor accessor;
        private readonly classroomContext _context;

        public RegistrationModel(IHttpContextAccessor _accessor, classroomContext context)
        {
            accessor = _accessor;
            _context = context;
        }
        public void saveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
