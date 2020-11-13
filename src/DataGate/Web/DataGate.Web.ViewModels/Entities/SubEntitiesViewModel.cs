namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class SubEntitiesViewModel : BaseEntityViewModel, IMapFrom<SubEntitiesGetDto>
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for all entities of type
        public List<string[]> Values { get; set; }

        public List<string> Headers { get; set; }

        public List<string> HeadersSelection { get; set; }

        public IReadOnlyCollection<string> PreSelectedColumns { get; set; }

        public IEnumerable<string> SelectedColumns { get; set; }

        public string Container { get; set; }
    }
}
