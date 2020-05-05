namespace DataGate.Web.ViewModels.Entities
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Mapping;

    public class GetWithSelectionDto : IMapFrom<EntitiesOverviewViewModel>
    {
        public DateTime? Date { get; set; }

        public IReadOnlyCollection<string> PreSelectedColumns { get; set; }

        public IEnumerable<string> SelectedColumns { get; set; }
    }
}
