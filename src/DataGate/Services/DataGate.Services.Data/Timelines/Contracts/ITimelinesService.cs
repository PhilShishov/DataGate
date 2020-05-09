namespace DataGate.Services.Data.Timelines.Contracts
{
    using System.Collections.Generic;

    public interface ITimelinesService
    {
        IEnumerable<T> GetTimeline<T>(int id);
    }
}
