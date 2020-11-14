namespace DataGate.Web.ViewModels.Agreements
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class AgreementOverviewViewModel
    {
        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public string Date { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<AgreementViewModel> Agreements { get; set; }
    }
}
