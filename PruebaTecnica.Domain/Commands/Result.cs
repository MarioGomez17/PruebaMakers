using PruebaTecnica.Domain.Errors;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnica.Domain.Commands
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFaulire => !IsSuccess;
        public Error Error { get; }
        protected internal Result(bool IsSuccess, Error Error)
        {
            if (IsSuccess && Error != Error.None)
            {
                throw new InvalidOperationException();
            }
            if (!IsSuccess && Error == Error.None)
            {
                throw new InvalidOperationException();
            }
            this.IsSuccess = IsSuccess;
            this.Error = Error;
        }
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error Error) => new(false, Error);
        public static Result<TValue> Success<TValue>(TValue Value) => new(Value, true, Error.None);
        public static Result<TValue> Failure<TValue>(Error Error) => new(default, false, Error);
        public static Result<TValue> Create<TValue>(TValue? Value) => Value is not null ? Success(Value) : Failure<TValue>(Error.NullValue);
    }
    public class Result<TValue> : Result
    {
        private readonly TValue? _Value;
        protected internal Result(TValue? Value, bool IsSuccess, Error Error) : base(IsSuccess, Error)
        {
            this._Value = Value;
        }
        [NotNull]
        public TValue Value => IsSuccess ? _Value! : throw new InvalidOperationException("El resultado del valor del error no es admisible");
        public static implicit operator Result<TValue>(TValue Value) => Create(Value);
    }
}
