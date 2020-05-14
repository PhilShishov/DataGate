namespace DataGate.Web.ViewModels.Queries
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Documents;

    public class SpecificEntityOverviewGetDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public IEnumerable<string[]> Entity { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public IEnumerable<DistinctDocViewModel> DistinctDocuments { get; set; }

        public IEnumerable<DistinctAgrViewModel> DistinctAgreements { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public IEnumerable<string[]> Values { get; set; }

        public IEnumerable<string> HeadersSelection { get; set; }
    }
}
