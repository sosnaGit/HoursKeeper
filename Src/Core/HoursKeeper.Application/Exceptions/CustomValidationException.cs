using System;
using System.Linq;
using System.Collections.Generic;
using FluentValidation.Results;

namespace HoursKeeper.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(IList<ValidationFailure> errors)
            : base(string.Join(" ", errors.Select(x => x.ErrorMessage)))
        {
        }
    }
}
