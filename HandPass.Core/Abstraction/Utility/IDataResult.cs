namespace HandPass.Core.Abstraction.Utility
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
