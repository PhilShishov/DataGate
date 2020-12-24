// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Redis.Contracts
{
    using StackExchange.Redis;

    public interface IProxy
    {
        string KeyNameSpace { get; }

        IDatabaseAsync ProxyDatabase { get; }
    }
}