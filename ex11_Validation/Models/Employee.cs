using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ex11_Validation.Validations;

namespace ex11_Validation.Models
{
    public class Employee : Person
    {
        [RangeSalaryValidation(minSalary: 400, maxSalary: 5500)]
        public double Salary { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
