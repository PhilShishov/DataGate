using System;
using System.Collections.Generic;

namespace DataGate.Web.Dtos.Queries
{
    public class GetAllWithSelectionDto
    {
        public DateTime? ChosenDate { get; set; } = null;

        public IReadOnlyCollection<string> PreSelectedColumns { get; set; }

        public IEnumerable<string> SelectedColumns { get; set; }
    }
}