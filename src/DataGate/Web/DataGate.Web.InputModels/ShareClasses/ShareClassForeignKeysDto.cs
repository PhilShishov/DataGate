namespace DataGate.Web.InputModels.ShareClasses
{
    using DataGate.Services.Mapping;

    public class ShareClassForeignKeysDto : IMapFrom<EditShareClassInputModel>, IMapFrom<CreateShareClassInputModel>
    {
        public string Status { get; set; }

        public string InvestorType { get; set; }

        public string ShareType { get; set; }

        public string CountryIssue { get; set; }

        public string CountryRisk { get; set; }
    }
}
