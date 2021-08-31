using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ex11_Validation.Models;
using FluentValidation;


namespace ex11_Validation.Validations.Validators
{
    public class DirectorValidator : AbstractValidator<Director>
    {
        public DirectorValidator()
        {
            RuleFor(d => d.Experience).InclusiveBetween(10, 35);
            RuleFor(d => d.CompanyName).MaximumLength(20);
        }
    }
}
