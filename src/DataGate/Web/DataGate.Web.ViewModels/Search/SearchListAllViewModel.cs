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

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public string SearchString { get; set; }

        public int NextPage
        {
            get
            {
                if (this.CurrentPage >= this.PagesCount)
                {
                    return 1;
                }

                return this.CurrentPage + 1;
            }
        }

        public int PreviousPage
        {
            get
            {
                if (this.CurrentPage <= 1)
                {
                    return this.PagesCount;
                }

                return this.CurrentPage - 1;
            }
        }
    }
}
