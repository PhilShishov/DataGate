namespace DataGate.Web.ViewModels.Agreements
{
    using System.Collections.Generic;

    public class AgreementsViewModel
    {
        public string Date { get; set; }

        public string Command { get; set; }

        public string Selected { get; set; }

        public IEnumerable<string[]> Agreements { get; set; }
    }
}
