namespace HandPass.Core.Abstraction.Utility
{
    public interface IDataResult<T>: IResult
    {
        T Data { get; }
    }
}
