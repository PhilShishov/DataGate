namespace DataGate.Web.ViewModels.Search
{
    using System.Collections.Generic;
    using DataGate.Web.Infrastructure.Extensions;
    using Ganss.XSS;

    public class SearchListAllViewModel
    {
        public SearchListAllViewModel()
        {
            this.Results = new HashSet<ResultViewModel>();
        }

        public IEnumerable<ResultViewModel> Results { get; set; }

        public string Date { get; set; }

        public string SearchTerm { get; set; }

        public string CleanedSearch => this.SearchTerm.ReplaceSpecial();
    }
}
