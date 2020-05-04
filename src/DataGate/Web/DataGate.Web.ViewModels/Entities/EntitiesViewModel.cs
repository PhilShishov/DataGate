namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class EntitiesViewModel : IMapFrom<GetAllDto>
    {
        public IEnumerable<string> Values { get; set; }
    }
}
