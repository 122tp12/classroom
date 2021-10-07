using System;
using System.Collections.Generic;

#nullable disable

namespace Classroom
{
    public partial class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
    }
}
