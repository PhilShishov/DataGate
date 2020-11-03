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
                case EndpointsConstants.FundAreaName:
                    result = fund;
                    break;
                case EndpointsConstants.SubFundAreaName:
                    result = subFund;
                    break;
                case EndpointsConstants.ShareClassAreaName:
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
                case EndpointsConstants.FundsControllerName:
                case EndpointsConstants.FundDetailsControllerName:
                case EndpointsConstants.FundSubFundsControllerName:
                    result = fund;
                    break;
                case EndpointsConstants.SubFundsControllerName:
                case EndpointsConstants.SubFundDetailsControllerName:
                case EndpointsConstants.SubFundShareClassesControllerName:
                    result = subFund;
                    break;
                case EndpointsConstants.ShareClassesControllerName:
                case EndpointsConstants.ShareClassDetailsControllerName:
                    result = shareClass;
                    break;
            }

            return result;
        }
    }
}
