namespace DataGate.Common.Exceptions
{
    using System;
    using System.Data.SqlClient;

    public class CustomSqlException : Exception
    {
        public CustomSqlException()
        {
        }

        public CustomSqlException(string message, SqlException innerException)
            : base(message, innerException)
        {
        }
    }
}
