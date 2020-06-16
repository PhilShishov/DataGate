namespace DataGate.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Services.Slug;
    using DataGate.Web.Dtos.Queries;

    public class DistinctAgrViewModel : IMapFrom<DistinctAgrDto>
    {
        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }

        public int FileId { get; set; }

        public string SluggedName => $"{new SlugGenerator().GenerateSlug(this.Name)}";
    }
}
