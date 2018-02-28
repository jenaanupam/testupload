using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class EndUserDetailsModel:UserDetailsModel
    {

        public string email { get; set; }
        public string DocumentName { get; set; }
        public string Referalcode { get; set; }
        public string Password { get; set; }
    }
}
