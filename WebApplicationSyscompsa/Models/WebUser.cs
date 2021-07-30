using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models
{
    public class WebUser
    {
        public int    id          { get; set; } 
        public string user_name   { get; set; } 
        public string user_pass   { get; set; } 
        public string user_email  { get; set; } 
        public string tipo        { get; set; } 
    }
}
