using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class User
    {
        public User()
        {
            GroupUsers = new HashSet<GroupUser>();
            Groups = new HashSet<Group>();
            Reaplies = new HashSet<Reaply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }

        public virtual ICollection<GroupUser> GroupUsers { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Reaply> Reaplies { get; set; }
    }
}
