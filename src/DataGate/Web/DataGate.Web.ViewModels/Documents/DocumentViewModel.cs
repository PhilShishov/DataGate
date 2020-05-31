namespace DataGate.Web.ViewModels.Documents
{
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class DocumentViewModel : IMapFrom<DocumentDto>
    {
        public string Description { get; set; }

        public string ValidFrom { get; set; }

        public string ValidUntil { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int FileId { get; set; }
    }
}
