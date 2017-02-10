using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWebApplication.Models
{
    public class BookModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }

    }
}