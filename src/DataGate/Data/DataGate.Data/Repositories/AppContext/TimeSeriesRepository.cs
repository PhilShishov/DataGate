// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Repositories.AppContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories.AppContext;

    public class TimeSeriesRepository : ITimeSeriesRepository
    {
        public TimeSeriesRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected ApplicationDbContext Context { get; set; }

        public async Task<string> ByName(string area, int? id)
        {
            var result = string.Empty;

            if (area == EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)
            {
                result = await this.Context.TbHistorySubFund
                    .Where(sf => sf.SfId == id)
                    .Select(f => f.SfOfficialSubFundName)
                    .FirstOrDefaultAsync();
            }
            else if (area == EndpointsConstants.ShareClassArea)
            {
                result = await this.Context.TbHistoryShareClass
                   .Where(sf => sf.ScId == id)
                   .Select(f => f.ScOfficialShareClassName)
                   .FirstOrDefaultAsync();
            }

            return result;

        }

        public ISet<string> All(string area)
        {
            var result = new HashSet<string>();
            if (area == EndpointsConstants.DisplaySub + EndpointsConstants.FundArea)
            {
                result = this.Context.TbHistorySubFund.Select(f => f.SfOfficialSubFundName).ToHashSet();
            }
            else if (area == EndpointsConstants.ShareClassArea)
            {
                result = this.Context.TbHistoryShareClass.Select(f => f.ScOfficialShareClassName).ToHashSet();
            }

            return result;
        }

        public IReadOnlyCollection<string> AllTbDomTimeSeriesType(int type)
        => this.Context.TbDomTimeseriesType
            .Where(tst => tst.EntityType == type)
            .Select(tst => tst.DescTs)
            .ToList();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
