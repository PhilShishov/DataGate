namespace DataGate.Web.ViewModels.Entities
{
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class DistinctDocViewModel : IMapFrom<DistinctDocDto>
    {
        public string Description { get; set; }

        public string Name { get; set; }
    }
}
