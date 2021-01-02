// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Timelines
{
    using System.Collections.Generic;
    using System.Linq;

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

        public IEnumerable<T> All<T>(string function, int id)
        {
            IEnumerable<TimelineDto> dto = this.sqlManager.ExecuteQueryMapping<TimelineDto>(function, id);

            return AutoMapperConfig.MapperInstance.Map<IEnumerable<T>>(dto.OrderByDescending(d => d.InitialDate));
        }
    }
}
