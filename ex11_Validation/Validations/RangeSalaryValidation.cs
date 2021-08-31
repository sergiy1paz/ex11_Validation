using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ex11_Validation.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeSalaryValidation : ValidationAttribute
    {
        private readonly double _maxSalary;
        private readonly double _minSalary;
        public RangeSalaryValidation(double maxSalary, double minSalary)
        {
            _maxSalary = maxSalary;
            _minSalary = minSalary;
        }

        public override bool IsValid(object value)
        {
            var currentSalary = (double)value;

            if (currentSalary < _minSalary)
            {
                ErrorMessage = "Salary must bе higher!";
                return false;
            }

            if (currentSalary > _maxSalary)
            {
                ErrorMessage = "Salary must be less!";
                return false;
            }


            return true;
        }

       
    }
}
