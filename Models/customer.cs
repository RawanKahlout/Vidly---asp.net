using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace myvidly.Models
{
    public class customer
    {
       
        [Display (Name ="Name")]
        [Required (ErrorMessage ="Please Enter the name")]
        public string customerName { get; set; }
        public int id { get; set; }
        public bool isSubscibedToNewsLetter { get; set; }
        [Display(Name = "Member ship type")]
        public membershipType membershipType { get; set; }//navagtion proprtey load entire object its usefull when we need to load objects togther
        [Display(Name ="Membership Type")]
        public byte membershipTypeId { get; set; }// mvc recognize this name and treat it as foreign key;
        [Display(Name = "Birth date")]
        [minAge]
        public Nullable <DateTime> BirthData { get;set;}
    }
}