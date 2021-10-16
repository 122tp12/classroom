using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Classes
{
    public class DbInitializer
    {
        public static void Initialize(classroomContext context)
        {
            context.Database.EnsureCreated();

            if (context.Groups.Any())
            {
                return;   // DB has been seeded
            }

            var groups = new Group[]
            {
                new Group { Id = 1, Name = "Rpz", Description = "desc" }
            };

            var groupUsers = new GroupUser[]
            {
                new GroupUser { Id = 1, IdGroup = 1, IdUser = 1 }
            };

            var reaplies = new Reaply[]
            {
                new Reaply { Id = 1, IdTask = 1, IdTaskNavigation = null }
            };

            var tasks = new Task[]
            {
                new Task { Id = 1, Name = "asdas", Description = "asda", Type = "asd", FilePaths = "asdsa", DatePublished = new DateTime(1999, 1, 1), IdGroup = 1 }
            };

            var users = new User[]
            {
                new User { Id = 1, Name = "asdas", Email = "adsa", ImgPath = "adss", Description = "asdsa", Password="asasdas" }
            };
        }
    }
}
