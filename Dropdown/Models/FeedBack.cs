using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dropdown.Models
{
    public class FeedBack
    {
        
        public int FeedbackID { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
    }
}