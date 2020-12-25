// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.CountriesDist
{
    using System.Collections.Generic;

    public interface ICountryDistService
    {
        IEnumerable<TDestination> All<TDestination>(string function, int id);
    }
}
