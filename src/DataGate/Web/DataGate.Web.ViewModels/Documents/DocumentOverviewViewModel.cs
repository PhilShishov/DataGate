namespace DataGate.Web.ViewModels.Documents
{
    using System.Collections.Generic;

    public class DocumentOverviewViewModel
    {
        public IEnumerable<DocumentViewModel> Documents { get; set; }

        public string AreaName { get; set; }
    }
}
