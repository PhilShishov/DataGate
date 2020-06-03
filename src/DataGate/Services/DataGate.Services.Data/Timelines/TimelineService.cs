namespace DataGate.Services.Data.Timelines
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class TimelineService : ITimelineService
    {
        private readonly ISqlQueryManager sqlManager;

        public TimelineService(ISqlQueryManager sqlQueryManager)
        {
            this.sqlManager = sqlQueryManager;
        }

        public IEnumerable<T> GetTimeline<T>(string function, int id)
        {
            IEnumerable<TimelineDto> dto = this.sqlManager.ExecuteQueryMapping<TimelineDto>(function, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
