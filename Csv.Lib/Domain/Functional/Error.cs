using Csv.Lib.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csv.Lib.Domain.Functional
{
    public enum ErrorType
    {
        None,
        NotFound,
        Validation,
        Exception
    }

    public class Error
    {
        public ErrorType Type { get; }
        public string Message { get; }

        protected Error(ErrorType type, string message)
        {
            Type = type;
            Message = message;
        }

        public override string ToString() => Message;

        public static Error None() => new Error(ErrorType.None, "");
        public static Error NotFound() => new Error(ErrorType.NotFound, "Record not found");
        public static ValidationError Validation(List<ValidationRule> validations) 
            => new ValidationError(ErrorType.Validation, "Validation failed", validations);
        public static Error Exception(string message) => new Error(ErrorType.Exception, message);
    }

    public class ValidationError : Error
    {
        public List<ValidationRule> Validations { get; }

        public ValidationError(ErrorType type, string message, List<ValidationRule> validations) :
            base(type, message)
        {
            this.Validations = validations;
        }
    }
}
