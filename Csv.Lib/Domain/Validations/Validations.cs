using Csv.Lib.Domain.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csv.Lib.Domain.Validations
{
    public class ValidationRule
    {
        public string Field { get; }
        public string Message { get; }

        public ValidationRule(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }

    public static class ValidationsExt
    {
        public static bool HasRules(this List<ValidationRule> @this)
            => @this.Count > 0;

        public static List<ValidationRule> AddIf(
            this List<ValidationRule> @this,
            string field, bool condition, string message)
        {
            if (condition)
            {
                @this.Add(new ValidationRule(field, message));
            }
            return @this;
        }
        
        public static List<ValidationRule> OnValid(
            this List<ValidationRule> @this,
            Func<List<ValidationRule>, List<ValidationRule>> func)
        {
            if (!@this.HasRules())
                return func(@this);

            return @this;
        }

        public static List<ValidationRule> OnValid(
            this List<ValidationRule> @this,
            Func<List<ValidationRule>, List<ValidationRule>> successFn,
            Func<List<ValidationRule>, List<ValidationRule>> failFn)
        {
            if (!@this.HasRules())
            {
                return successFn(@this);
            }

            return failFn(@this);
        }
    }
}
