using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.Index
{
    public class ReaplyModel : PageModel
    {
        classroomContext context;
        public int currentId;
        public ReaplyModel(classroomContext _context)
        {
            context = _context;
        }
        public void saveReaply(Reaply reaply)
        {
            context.Reaplies.Add(reaply);
            context.SaveChanges();
        }
    }
}
