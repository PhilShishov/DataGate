// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Common
{
    using System;
    using System.Threading.Tasks;

    public interface IStorageService
    {
        T ByIdAndDate<T>(int id, string date);

        Task<bool> DoesExist(string name);

        Task<bool> DoesExistAtDate(string fundName, DateTime initialDate);
    }
}
