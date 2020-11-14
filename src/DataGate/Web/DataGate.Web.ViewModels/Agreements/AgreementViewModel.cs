namespace DataGate.Web.ViewModels.Agreements
{
    using DataGate.Services.Mapping;
    using DataGate.Services.Slug;
    using DataGate.Web.Dtos.Queries;

    public class AgreementViewModel : IMapFrom<AllAgreementDto>
    {
        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string ContractDate { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public string SluggedName => $"{new SlugGenerator().GenerateSlug(this.Name)}";
    }
}
