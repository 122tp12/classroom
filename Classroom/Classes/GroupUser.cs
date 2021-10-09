using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class GroupUser
    {
        public int Id { get; set; }
        public int? IdGroup { get; set; }
        public int? IdUser { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
