using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class UserDetailsModel :baseModel
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string username  { get; set; }
        public string password { get; set; }
        public string AccessType { get; set; }
    }
}
