namespace HandPass.Core.Abstraction.Utility
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
