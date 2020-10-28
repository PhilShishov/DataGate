namespace DataGate.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataGate.Common;
    using DataGate.Data.Common.Repositories;

    public class EntityRepository : IEntityRepository
    {
        public EntityRepository(Pharus_vFinaleDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected Pharus_vFinaleDbContext Context { get; set; }

        public Task<string> ByName(string area, int id)
        {
            throw new System.NotImplementedException();
        }

        public ISet<string> GetAll(string area)
        {
            var result = new HashSet<string>(); 
            if (area == GlobalConstants.SubFundAreaName)
            {
                result = this.Context.TbHistorySubFund.Select(f => f.SfOfficialSubFundName).ToHashSet();
            }
            else if(area == GlobalConstants.ShareClassAreaName)
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
