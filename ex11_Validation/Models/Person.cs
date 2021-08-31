using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ex11_Validation.Models
{
    public abstract class Person : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (Age < 18)
            {
                result.Add(new ValidationResult("This person is too young", new[] { "Age" }));
            } else if (Age > 65)
            {
                result.Add(new ValidationResult("This person is too old", new[] { "Age" }));
            }


            return result;
        }
    }
}
