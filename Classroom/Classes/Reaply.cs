using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class Reaply
    {
        public int Id { get; set; }
        public string ReaplyPath { get; set; }
        public int? IdTask { get; set; }

        public virtual Task IdTaskNavigation { get; set; }
    }
}
