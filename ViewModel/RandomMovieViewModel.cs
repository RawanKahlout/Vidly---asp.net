using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myvidly.Models;
namespace myvidly.ViewModel
{
    public class RandomMovieViewModel
    {
       public movie movies { get; set; } 
       public List <customer> customers { get; set; }
    }
}