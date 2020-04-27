namespace DataGate.Web.ViewModels.Agreements
{
    using System.Collections.Generic;

    public class AgreementsViewModel
    {
        public string ChosenDate { get; set; }

        public string SelectedItem { get; set; }

        public string SearchTerm { get; set; }

        public string Command { get; set; }

        public List<string[]> FundAgreements { get; set; }

        public List<string[]> SubFundAgreements { get; set; }

        public List<string[]> ShareClassAgreements { get; set; }
    }
}
