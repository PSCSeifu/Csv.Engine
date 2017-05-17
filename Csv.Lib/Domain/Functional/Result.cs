using Csv.Lib.Domain.Functional;
using Csv.Lib.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csv.Lib.Domain.Functional
{
    public class Result<S, F>
    {
        public S SuccessValue { get; }
        public F FailureValue { get; }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        internal Result(S successValue)
        {
            IsSuccess = true;
            SuccessValue = successValue;
            FailureValue = default(F);
        }

        internal Result(F failureValue)
        {
            IsSuccess = false;
            FailureValue = failureValue;
            SuccessValue = default(S);
        }

        public static Result<S, F> Ok(S successValue)
            => new Result<S, F>(successValue);

        public static Result<S, F> Fail(F failureValue)
            => new Result<S, F>(failureValue);

        public TR Match<TR>(Func<S, TR> successFn, Func<F, TR> failureFn)
           => IsSuccess ? successFn(this.SuccessValue) : failureFn(this.FailureValue);

        public Unit Match(Action<S> success, Action<F> failure)
           => Match(success.ToFunc(), failure.ToFunc());        
    }

    public static class ResultExt
    {
        public static Result<R, F> Map<S, F, R>
           (this Result<S, F> @this, Func<S, R> fn)
        =>
            @this.Match(
                s => Result<R, F>.Ok(fn(s)),
                f => Result<R, F>.Fail(f));

        public static Result<R, F> Bind<S, F, R>
           (this Result<S, F> @this, Func<S, Result<R, F>> fn)
        =>
            @this.Match(
                s => fn(s),
                f => Result<R, F>.Fail(f));

        public static Result<S, F> Do<S, F>(
            this Result<S, F> @this, Action<S> successFn)
        {
            if (@this.IsSuccess)
                successFn(@this.SuccessValue);
            return @this;
        }

        public static Result<S, F> Do<S, F>(
            this Result<S, F> @this, Action<S> successFn, Action<F> failureFn)
        {
            if (@this.IsSuccess)
                successFn(@this.SuccessValue);
            if (@this.IsFailure)
                failureFn(@this.FailureValue);
            return @this;
        }
        
        public static Result<S, Error> ToResult<S, F>(
            this Exceptional<S> @this)
        {
            return @this.Success ?
                    Result<S, Error>.Ok(@this.Value) :
                    Result<S, Error>.Fail(Error.Exception(@this.Ex.Message));
        }

        public static Result<T, Error> ToResult<T>(
            this List<ValidationRule> @this, T model)
        {
            return @this.HasRules() ?
                        Result<T, Error>.Fail(Error.Validation(@this)) :
                        Result<T, Error>.Ok(model);
        }
    }
}
