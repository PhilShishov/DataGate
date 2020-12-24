// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Storage.Contracts
{
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Web.InputModels.ShareClasses;

    public interface IShareClassStorageService : IStorageService
    {
        Task<int> Edit(EditShareClassInputModel model);

        Task<int> Create(CreateShareClassInputModel model);
    }
}
