// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value) => value ? "Yes" : "No";
    }
}
