// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace DataGate.Services.Data.Common
{
    public interface IEntityException
    {
        Task<bool> DoesExist(int id);
    }
}
