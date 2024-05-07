using System;

namespace ValidatorLibrary
{
    public interface IValidator
    {
        bool Validate(string validateObject);
    }
}
