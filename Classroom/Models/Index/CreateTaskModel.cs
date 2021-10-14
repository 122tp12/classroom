using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Models.Index
{
    public class CreateTaskModel: PageModel
    {
        public int idGroup;
        classroomContext context;
        public CreateTaskModel(classroomContext _context)
        {
            context = _context;
        }
        public int saveTask(Task t)
        {
            context.Tasks.Add(t);
            context.SaveChanges();
            return context.Tasks.OrderBy(n => n.Id).Last().Id;
        }
        public void SaveFile(IFormFile uploadedFile, int id)
        {
            if (uploadedFile != null)
            {
                string path = uploadedFile.FileName;
                Thread t = new Thread(new ParameterizedThreadStart((object o) => {
                    IFormFile fileFrom = (IFormFile)o;
                    using (var fileStream = new FileStream("wwwroot\\tasksFiles\\" + id, FileMode.Create))
                    {
                        fileFrom.CopyToAsync(fileStream);
                    }
                }));
                t.Start(uploadedFile);
                // сохраняем файл в папку Files в каталоге wwwroot
            }
        }
    }
}
