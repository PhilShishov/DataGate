namespace DataGate.Web.ViewModels.Documents
{
    using DataGate.Services.Mapping;
    using DataGate.Services.Slug;
    using DataGate.Web.Dtos.Queries;

    public class AgreementViewModel : IMapFrom<AgreementDto>
    {
        public string Description { get; set; }

        public string ContractDate { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public string SluggedName => $"{new SlugGenerator().GenerateSlug(this.Name)}";
    }
}
