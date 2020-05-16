namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class EntitySubEntitiesViewModel : IMapFrom<EntitySubEntitiesGetDto>
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Container { get; set; }

        public List<string[]> Entities { get; set; }
    }
}
