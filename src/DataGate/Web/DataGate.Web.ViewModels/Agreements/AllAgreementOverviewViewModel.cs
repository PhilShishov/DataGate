namespace DataGate.Web.ViewModels.Agreements
{
    using System.Collections.Generic;

    public class AllAgreementOverviewViewModel
    {
        public string Date { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<AllAgreementViewModel> Agreements { get; set; }
    }
}
