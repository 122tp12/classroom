using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.UserProfile
{
    public class ProfileModel : PageModel
    {
        public User user;
        classroomContext context;
        public ProfileModel(classroomContext _context)
        {
            context = _context;
        }
        public void getUser(int _userId)
        {
            user=context.Users.Where(n => n.Id == _userId).FirstOrDefault();
            user.Name=user.Name.Trim();
            user.Description = user.Description.Trim();
            user.Password = user.Password.Trim();
            user.Email = user.Email.Trim();
        }
        public void SaveFile(IFormFile uploadedFile, int id)
        {
            if (uploadedFile != null)
            {
               
                    using (var fileStream = new FileStream("wwwroot\\profilePhoto\\" + id+".jpg", FileMode.Create))
                    {
                        uploadedFile.CopyTo(fileStream);
                    }
                // сохраняем файл в папку Files в каталоге wwwroot
            }
        }
        public void SaveUser(User u)
        {
            context.Users.Update(u);
            context.SaveChanges();
        }
    }
}
