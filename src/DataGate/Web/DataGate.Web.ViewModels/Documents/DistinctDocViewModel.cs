namespace DataGate.Web.ViewModels.Entities
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class DistinctDocViewModel : IMapFrom<DistinctDocDto>
    {
        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }
    }
}
