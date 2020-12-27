// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Redis.Contracts;

    public static class ProxyExtensions
    {
        public static Task<bool> KeyExists(this IProxy proxy, string keyName, bool useKeyNameSpace = true)
        {
            Validator.ArgumentNullException(proxy);

            var fullKeyName = useKeyNameSpace ? 
                $"{proxy.KeyNameSpace}:{keyName}" : 
                keyName;
            return proxy.ProxyDatabase.KeyExistsAsync(fullKeyName);
        }

        public static Task<bool> DeleteKey(this IProxy proxy, string keyName, bool useKeyNameSpace = true)
        {
            Validator.ArgumentNullException(proxy);

            var fullKeyName = useKeyNameSpace ? 
                $"{proxy.KeyNameSpace}:{keyName}" : 
                keyName;
            return proxy.ProxyDatabase.KeyDeleteAsync(fullKeyName);
        }
    }
}