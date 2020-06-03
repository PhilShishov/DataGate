namespace DataGate.Services.Data.Timelines
{
    using System.Collections.Generic;

    public interface ITimelineService
    {
        IEnumerable<T> GetTimeline<T>(string function, int id);
    }
}
