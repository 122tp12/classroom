using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class Reaply
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? IdTask { get; set; }
        public int? IdUser { get; set; }
        public string Description { get; set; }

        public virtual Task IdTaskNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
