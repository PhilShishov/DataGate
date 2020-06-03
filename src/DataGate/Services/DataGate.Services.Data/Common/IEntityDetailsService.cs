namespace DataGate.Services.Data.Common
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.Dtos.Queries;

    public interface IEntityDetailsService : IContainerService, ICustomException
    {
        IEnumerable<string[]> GetByIdAndDate(int id, DateTime? date);

        IEnumerable<DistinctDocDto> GetDistinctDocuments(int id, DateTime? date);

        IEnumerable<DistinctAgrDto> GetDistinctAgreements(int id, DateTime? date);
    }
}
