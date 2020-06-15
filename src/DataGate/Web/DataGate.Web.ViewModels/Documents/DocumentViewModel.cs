namespace DataGate.Web.ViewModels.Documents
{
    using DataGate.Services.Mapping;
    using DataGate.Services.Slug;
    using DataGate.Web.Dtos.Queries;

    public class DocumentViewModel : IMapFrom<DocumentDto>
    {
        public string Description { get; set; }

        public string ValidFrom { get; set; }

        public string ValidUntil { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int FileId { get; set; }

        public string SluggedName => $"{new SlugGenerator().GenerateSlug(this.Name)}";
    }
}
