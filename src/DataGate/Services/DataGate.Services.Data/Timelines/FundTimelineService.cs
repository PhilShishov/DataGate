namespace DataGate.Services.Data.Timelines
{
    using System.Collections.Generic;

    using DataGate.Services.Data.Timelines.Contracts;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Queries;

    public class FundTimelineService : ITimelinesService
    {
        private readonly string sqlFunctionTimelineFund = "[fn_timeline_fund]";

        private readonly ISqlQueryManager sqlManager;

        public FundTimelineService(ISqlQueryManager sqlQueryManager)
        {
            this.sqlManager = sqlQueryManager;
        }

        public IEnumerable<T> GetTimeline<T>(int id)
        {
            IEnumerable<TimelineDto> dto = this.sqlManager.ExecuteQueryMapping<TimelineDto>(this.sqlFunctionTimelineFund, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto);
        }
    }
}
