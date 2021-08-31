using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ex11_Validation.Models
{
    public class Director : Person
    {
        public string CompanyName { get; set; }
        public int Experience { get; set; }
    }
}
