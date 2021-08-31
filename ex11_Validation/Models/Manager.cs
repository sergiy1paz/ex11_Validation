using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ex11_Validation.Validations;

namespace ex11_Validation.Models
{
    [ManagerLanguageValidation(permittedLanguages: new[] { "English", "German", "Spanish" })]
    public class Manager : Person
    {
        [RangeSalaryValidation(minSalary: 450, maxSalary: 2500)]
        public double Salary { get; set; }
        public string Language { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
