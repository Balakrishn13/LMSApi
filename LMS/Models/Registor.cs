using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Registor
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        
        public string Password { get; set; }

        public DateTime DateTime { get; set; }
    }
}
