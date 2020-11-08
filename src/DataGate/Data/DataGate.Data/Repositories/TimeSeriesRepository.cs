namespace DataGate.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Common.Repositories;
    using Microsoft.EntityFrameworkCore;

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

        public ISet<string> GetAll(string area)
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

        public IReadOnlyCollection<string> GetAllTbDomTimeSeriesType(int type)
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
