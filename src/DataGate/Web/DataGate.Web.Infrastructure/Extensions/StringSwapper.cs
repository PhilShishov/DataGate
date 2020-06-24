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
                case GlobalConstants.FundAreaName:
                    result = fund;
                    break;
                case GlobalConstants.SubFundAreaName:
                    result = subFund;
                    break;
                case GlobalConstants.ShareClassAreaName:
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
                case GlobalConstants.FundsControllerName:
                case GlobalConstants.FundDetailsControllerName:
                case GlobalConstants.FundSubFundsControllerName:
                    result = fund;
                    break;
                case GlobalConstants.SubFundsControllerName:
                case GlobalConstants.SubFundDetailsControllerName:
                case GlobalConstants.SubFundShareClassesControllerName:
                    result = subFund;
                    break;
                case GlobalConstants.ShareClassesControllerName:
                case GlobalConstants.ShareClassDetailsControllerName:
                    result = shareClass;
                    break;
            }

            return result;
        }
    }
}
