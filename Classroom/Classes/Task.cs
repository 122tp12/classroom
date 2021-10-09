using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class Task
    {
        public Task()
        {
            Reaplies = new HashSet<Reaply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string FilePaths { get; set; }
        public DateTime DatePublished { get; set; }
        public int? IdGroup { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual ICollection<Reaply> Reaplies { get; set; }
    }
}
