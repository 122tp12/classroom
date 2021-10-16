using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.GroupC
{
    public class CreateGroupModel
    {
        classroomContext context;
        public CreateGroupModel(classroomContext _context)
        {
            context = _context;
        }
        public void saveGroupUserRelationship(int _idUser, string _name, string _description, string _password)
        {
            Group group = new Group() {Description= _description, Name=_name, Password=_password, IdOwner=_idUser};
            context.Groups.Add(group);
            context.SaveChanges();
        }
    }
}
