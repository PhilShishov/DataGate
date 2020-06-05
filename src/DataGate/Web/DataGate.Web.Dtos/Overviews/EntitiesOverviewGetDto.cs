namespace DataGate.Web.Dtos.Overviews
{
    using System.Collections.Generic;

    public class EntitiesOverviewGetDto
    {
        public string Date { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<string[]> Values { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public IEnumerable<string> HeadersSelection { get; set; }
    }
}
