namespace DataGate.Services.Data.Timelines.Common
{
    using System.Collections.Generic;

    public interface ITimelineService
    {
        IEnumerable<T> GetTimeline<T>(int id);
    }
}
