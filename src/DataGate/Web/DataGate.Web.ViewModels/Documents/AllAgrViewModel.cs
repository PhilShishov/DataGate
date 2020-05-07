namespace DataGate.Web.ViewModels.Documents
{
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class AllAgrViewModel : IMapFrom<AllAgrDto>
    {
        public string Description { get; set; }

        public string ContractDate { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        public string Name { get; set; }
    }
}
