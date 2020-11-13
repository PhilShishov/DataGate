namespace DataGate.Services.Redis.Contracts
{
    using StackExchange.Redis;

    public interface IProxy
    {
        string KeyNameSpace { get; }

        IDatabaseAsync DB { get; }
    }
}