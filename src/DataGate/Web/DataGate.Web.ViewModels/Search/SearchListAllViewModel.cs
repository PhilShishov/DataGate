namespace DataGate.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchListAllViewModel
    {
        public SearchListAllViewModel()
        {
            this.Results = new HashSet<ResultViewModel>();
        }

        public IEnumerable<ResultViewModel> Results { get; set; }

        public string Date { get; set; }

        public string SearchTerm { get; set; }
    }
}
