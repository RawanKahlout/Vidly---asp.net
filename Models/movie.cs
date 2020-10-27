using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace myvidly.Models
{
    public class movie
    {
        public int id { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public DateTime RealeseDate { get; set; }
        [Required]
        public DateTime AddTime { get; set; }
        [Required]
        [stockQTY]
        public int Stock { get; set; }
        [Required]
        public genre genre { get; set; }
        [Required]
        public byte genreId { get; set; }
    }
}