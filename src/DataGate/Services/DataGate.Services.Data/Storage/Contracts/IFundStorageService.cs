// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Storage.Contracts
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Web.InputModels.Funds;

    public interface IFundStorageService : IStorageService
    {
        Task<int> Edit(EditFundInputModel model);

        Task<int> Create(CreateFundInputModel model);
    }
}
