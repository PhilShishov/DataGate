namespace DataGate.Web.Dtos.Overviews
{
    using System.Collections.Generic;

    public class EntitySubEntitiesGetDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Container { get; set; }

        public string Function { get; set; }

        public IEnumerable<string[]> Entities { get; set; }
    }
}
