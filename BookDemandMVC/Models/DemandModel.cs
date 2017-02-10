using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookDemandMVC.Models
{
    public class DemandModel
    {
        [Required]     
        public string ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string BookID { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}