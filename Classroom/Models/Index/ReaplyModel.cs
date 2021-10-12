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
        public int userId;
        public ReaplyModel(classroomContext _context)
        {
            context = _context;
        }
        public void saveReaply(Reaply reaply)
        {
            context.Reaplies.Add(reaply);
            context.SaveChanges();
        }
        public int deleteReaply(int id)
        {
            Reaply r=context.Reaplies.Where(n => n.Id == id).FirstOrDefault();
            context.Reaplies.Remove(r);
            context.SaveChanges();
            return r.IdTask.Value;
        }
    }
}
