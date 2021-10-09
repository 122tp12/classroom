using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class Group
    {
        public Group()
        {
            GroupUsers = new HashSet<GroupUser>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IdOwner { get; set; }

        public virtual User IdOwnerNavigation { get; set; }
        public virtual ICollection<GroupUser> GroupUsers { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
