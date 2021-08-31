using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ex11_Validation.Models;
using Microsoft.AspNetCore.Mvc;
using ex11_Validation.Database;


namespace ex11_Validation.Validations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ManagerLanguageValidation : ValidationAttribute
    {
        private readonly string[] _permittedLanguages;

        public ManagerLanguageValidation(string[] permittedLanguages)
        {
            _permittedLanguages = permittedLanguages;
        }

        public override bool IsValid(object value)
        {
            var manager = (Manager)value;

            if (!_permittedLanguages.Contains(manager.Language))
            {
                ErrorMessage = "Manager must know one language of the list: " + string.Join(", ", _permittedLanguages);
                return false;
            }

            return true;
        }
    }
}
