namespace DataGate.Common.Exceptions
{
    using System;

    public class BadRequestException : ArgumentException
    {
        private const string DefaultMessage = "The request was not correct.";

        public BadRequestException()
            : base(DefaultMessage)
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
