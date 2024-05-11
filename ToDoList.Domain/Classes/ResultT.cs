namespace ToDoList.Domain.Classes
{
    public class Result<TValue> : Result
    {
        private readonly TValue _value;
        public TValue Value => IsSuccess ?
            _value
            : throw new ArgumentException("A failure result can't have it`s value accessed");

        protected internal Result(TValue value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
                throw new ArgumentException("Invalid Error for current success status", nameof(error));

            _value = value;
        }
    }
}
