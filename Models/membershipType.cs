using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myvidly.Models
{
    public class membershipType
    {
        public byte Id { get; set; }
        public byte duration { get; set; }
        public short signupFree { get; set; }
        public byte discountRate { get; set; }
        public string name { get; set; }
    }
}