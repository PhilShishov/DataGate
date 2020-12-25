// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Slug
{
    public interface ISlugGenerator
    {
        string Get(string str);
    }
}
