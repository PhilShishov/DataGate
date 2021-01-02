// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Infrastructure.Extensions
{
    using DataGate.Common;

    public static class StringSwapper
    {
        public static string ByArea(string currentType, string fund, string subFund, string shareClass)
        {
            string result = string.Empty;

            switch (currentType.Replace(" ", string.Empty))
            {
                case EndpointsConstants.FundArea:
                case EndpointsConstants.FundAbbreviation:
                    result = fund;
                    break;
                case EndpointsConstants.DisplaySub + EndpointsConstants.FundArea:
                case EndpointsConstants.SubFundAbbreviation:
                    result = subFund;
                    break;
                case EndpointsConstants.ShareClassArea:
                case EndpointsConstants.ShareClassAbbreviation:
                    result = shareClass;
                    break;
            }

            return result;
        }

        public static string ByController(string currentType, string fund, string subFund, string shareClass)
        {
            string result = string.Empty;

            switch (currentType.Replace(" ", string.Empty))
            {
                case EndpointsConstants.FundsController:
                case EndpointsConstants.FundArea + EndpointsConstants.ActionDetails:
                case EndpointsConstants.FundArea + EndpointsConstants.DisplaySub + EndpointsConstants.FundsController:
                    result = fund;
                    break;
                case EndpointsConstants.DisplaySub + EndpointsConstants.FundsController:
                case EndpointsConstants.DisplaySub + EndpointsConstants.FundArea + EndpointsConstants.ActionDetails:
                case EndpointsConstants.SubFundShareClassesController:
                    result = subFund;
                    break;
                case EndpointsConstants.ShareClassesController:
                case EndpointsConstants.ShareClassArea + EndpointsConstants.ActionDetails:
                    result = shareClass;
                    break;
            }

            return result;
        }
    }
}
