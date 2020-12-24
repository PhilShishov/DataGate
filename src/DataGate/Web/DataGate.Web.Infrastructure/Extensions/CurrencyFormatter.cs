// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using System.Globalization;

    public static class CurrencyFormatter
    {
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");

        public static string ToString(this decimal currency)
                => currency.ToString("€" + "##,0.00", Culture);
    }
}
