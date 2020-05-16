namespace DataGate.Web.Dtos.Queries
{
    using System.Collections.Generic;

    public class EntitySubEntitiesGetDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Container { get; set; }

        public IEnumerable<string[]> Entities { get; set; }
    }
}