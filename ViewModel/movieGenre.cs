using myvidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myvidly.ViewModel
{
    public class movieGenre
    {
        public movie movie { get; set; }
        public IEnumerable<genre> genre { get; set; }

    }
}