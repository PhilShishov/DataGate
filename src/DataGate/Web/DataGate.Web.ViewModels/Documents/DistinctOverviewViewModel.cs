namespace DataGate.Web.ViewModels.Documents
{
    using System.Collections.Generic;

    public class DistinctOverviewViewModel
    {
        public IEnumerable<DistinctDocViewModel> Documents { get; set; }

        public IEnumerable<DistinctAgrViewModel> Agreements { get; set; }

        public string AreaName { get; set; }
    }
}
