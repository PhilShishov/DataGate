// Abstract model class for view entity
// for code reuse

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    public abstract class BaseEntityViewModel
    {
        public IEnumerable<string[]> EntitiesHeadersForColumnSelection { get; set; }

        public string ChosenDate { get; set; }

        public string Command { get; set; }

        public int EntityId { get; set; }

        public string SelectTerm { get; set; }

        public List<string> PreSelectedColumns { get; set; }

        public List<string> SelectedColumns { get; set; }
    }
}