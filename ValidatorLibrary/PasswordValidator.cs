using System;
using System.Text.RegularExpressions;

namespace ValidatorLibrary
{

    // длина 8-20
    // симв.лат. + цифры + !@#$%^&*-_
    // Хотя бы 1 IsUpper, хотя бы 1 цифра, хотя бы 1 спец
    public class PasswordValidator : IValidator
    {
        public bool Validate(string validateObject)
        {
            if (string.IsNullOrEmpty(validateObject))
            {
                return false;
            }

            var passwordLengthIsValid = validateObject.Length >= 8 && validateObject.Length <= 20;
            var passwordPatternIsValid = 
                Regex.IsMatch(validateObject, "[a-zA-Z]")
                && Regex.IsMatch(validateObject, "[0-9]")
                && Regex.IsMatch(validateObject, "[!@#$%^&*-_]");

            return passwordLengthIsValid && passwordPatternIsValid;
        }
    }
}
