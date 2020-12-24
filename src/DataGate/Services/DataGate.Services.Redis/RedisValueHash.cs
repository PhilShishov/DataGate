// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Redis
{

    using StackExchange.Redis;

    public class RedisValueHash : RedisHash<RedisValue, RedisValue>
    {
        public RedisValueHash(string keyName)
            : base(keyName) { }
    }
}
