// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.ClassFixtures
{
    using DataGate.Common;
    using DataGate.Services.Redis.Configuration;

    public class RedisFixture
    {
        public RedisFixture()
        {
            // How to setup Redis for testing:
            //   1. Download redis server from here: 
            // https://github.com/microsoftarchive/redis/releases/tag/win-3.0.504

            //   2. Install should be C:\Program Files\Redis 

            //   3. Change your wwwrootpath

            //   4. Run tests 

            this.RedisConnection = new RedisConnection(
                GlobalConstants.RedisConnectionString,
                PathConstants.WwwRootPath);
        }

        public RedisConnection RedisConnection { get; set; }
    }
}
