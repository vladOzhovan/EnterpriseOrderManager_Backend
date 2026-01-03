namespace EnterpriseOrderManager.Domain.Helpers
{
    public record Result<T>(T? Value, bool Succeeded, string Error = "")
    {
        public static Result<T> Success(T value) => new(value, true);
        public static Result<T> Fail(string error) => new(default, false, error);
    }
}
