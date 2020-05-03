namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    public class EntitiesViewModel
    {
        public IEnumerable<string[]> Headers { get; set; }

        public IEnumerable<string[]> Values { get; set; }
    }
}
