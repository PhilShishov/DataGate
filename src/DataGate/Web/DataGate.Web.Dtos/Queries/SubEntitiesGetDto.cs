namespace DataGate.Web.Dtos.Queries
{
    using System.Collections.Generic;

    public class SubEntitiesGetDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public IEnumerable<string[]> Values { get; set; }

        public IEnumerable<string> Headers { get; set; }

        public IEnumerable<string> HeadersSelection { get; set; }

        public string Container { get; set; }
    }
}
