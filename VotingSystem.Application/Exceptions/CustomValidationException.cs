using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];
        public CustomValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }

        public CustomValidationException(string errorMessage)
        {
            ValidationErrors.Add(errorMessage);
        }
    }
}
