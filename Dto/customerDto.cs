using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myvidly.Models;
namespace myvidly.Dto
{
    public class customerDto
    {
        
        [Required(ErrorMessage = "Please Enter the name")]
        public string customerName { get; set; }
        public int id { get; set; }
        public bool isSubscibedToNewsLetter { get; set; }
        public membershipType membershipType { get; set; }//navagtion proprtey load entire object its usefull when we need to load objects togther
        public byte membershipTypeId { get; set; }// mvc recognize this name and treat it as foreign key;
        [minAge]
        public Nullable<DateTime> BirthData { get; set; }
    }
}