namespace DataGate.Web.ViewModels.Queries
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Entities;

    public class SpecificEntityOverviewGetDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<string[]> Entity { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public IEnumerable<string> HeadersSelection { get; set; }

        public IEnumerable<string[]> Values { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime EndConnection { get; set; }

        public IEnumerable<DistinctDocViewModel> DistinctDocuments { get; set; }

        public IEnumerable<DistinctDocViewModel> DistinctAgreements { get; set; }
    }
}
