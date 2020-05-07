namespace DataGate.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class AllDocViewModel : IMapFrom<AllDocDto>
    {
        public string Description { get; set; }

        public string ValidFrom { get; set; }

        public string ValidUntil { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
