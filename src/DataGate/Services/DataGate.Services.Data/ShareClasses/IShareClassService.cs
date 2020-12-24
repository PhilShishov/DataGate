// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.ShareClasses
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Common;
    using DataGate.Web.ViewModels.Search;

    public interface IShareClassService : IEntityException
    {
        IEnumerable<SearchViewModel> ByName(string searchTerm);

        IEnumerable<TbPrimeShareClass> ByDate();

        bool IsIsin(string searchTerm);

        int ByIsin(string searchTerm);
    }
}
