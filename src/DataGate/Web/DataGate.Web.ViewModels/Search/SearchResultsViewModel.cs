// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
