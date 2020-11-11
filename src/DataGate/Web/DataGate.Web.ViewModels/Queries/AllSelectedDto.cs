namespace DataGate.Web.ViewModels.Queries
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Entities;

    public class AllSelectedDto : IMapFrom<EntitiesViewModel>, IMapFrom<SubEntitiesViewModel>
    {
        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public IReadOnlyCollection<string> PreSelectedColumns { get; set; }

        public IEnumerable<string> SelectedColumns { get; set; }
    }
}
