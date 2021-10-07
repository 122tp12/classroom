using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models.Index
{
    public class IndexModel : PageModel
    {
        IHttpContextAccessor accessor;
        public IndexModel(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }
    }
}
