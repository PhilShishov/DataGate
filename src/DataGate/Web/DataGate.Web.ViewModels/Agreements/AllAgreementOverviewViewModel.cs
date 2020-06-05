namespace DataGate.Web.ViewModels.Agreements
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllAgreementOverviewViewModel
    {
        [Required]
        public string Date { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<AllAgreementViewModel> Agreements { get; set; }
    }
}
