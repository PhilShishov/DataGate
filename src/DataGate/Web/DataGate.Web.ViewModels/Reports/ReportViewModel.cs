namespace DataGate.Web.ViewModels.Reports
{
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class ReportViewModel : IMapFrom<ReportDto>
    {
        public string FundName { get; set; }

        public string FundAdminSFCode { get; set; }

        public string SubFundName { get; set; }

        public string CCY { get; set; }

        public string NAVFrequency { get; set; }

        public string EOMNAVDate { get; set; }

        public decimal AuMInEUR { get; set; }

        public int FundId { get; set; }

        public int SubFundId { get; set; }
    }
}
