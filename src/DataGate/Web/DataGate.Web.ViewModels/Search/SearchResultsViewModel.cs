namespace DataGate.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using DataGate.Web.Infrastructure.Extensions;

    public class SearchResultsViewModel
    {
        public SearchResultsViewModel()
        {
            this.Results = new HashSet<SearchViewModel>();
        }

        public IEnumerable<SearchViewModel> Results { get; set; }

        public string Date { get; set; }

        public string SearchTerm { get; set; }

        public string CleanedSearch => this.SearchTerm.ReplaceSpecial();
    }
}
