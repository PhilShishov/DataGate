namespace DataGate.Web.ViewModels.Documents
{
    using System.Collections.Generic;

    public class AgreementOverviewViewModel
    {
        public IEnumerable<AgreementViewModel> Agreements { get; set; }

        public string ControllerName { get; set; }
    }
}
