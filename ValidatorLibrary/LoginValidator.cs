using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    public class LoginValidator : IValidator
    {
        public bool Validate(string validateObject)
        {
            if (string.IsNullOrEmpty(validateObject))
                return false;
            
            return 
                validateObject.Length >= 6 
                && validateObject.Length <= 16
                && Regex.IsMatch(validateObject, "^[a-zA-Z]+$");
        }
    }
}
