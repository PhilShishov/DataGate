namespace DataGate.Common
{
    public static class QuerySwapper
    {
        public static string GetResult(string chosenType, string functionFund, string functionSubFund, string functionShareClass)
        {
            string result = string.Empty;

            if (chosenType == GlobalConstants.TypeFund)
            {
                result = functionFund;
            }
            else if (chosenType == GlobalConstants.TypeSubFund)
            {
                result = functionSubFund;
            }
            else if (chosenType == GlobalConstants.TypeShareClass)
            {
                result = functionShareClass;
            }

            return result;
        }
    }
}
