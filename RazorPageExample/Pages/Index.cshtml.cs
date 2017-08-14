using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageExample.Pages
{
    public class IndexModel : PageModel
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void OnGet()
        {
            var x = 1;
            var y = 2;
            var t = (x, y);
            X = t.x;
            Y = t.y;
        }
    }
}
