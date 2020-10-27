using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myvidly.Models;
using myvidly.ViewModel;
namespace myvidly.ViewModel
{
    public class customerMemberShip
    {
        public IEnumerable<membershipType> membershipTypes { get; set;}
        public customer customers { get; set; }
    }
}