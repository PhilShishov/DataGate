// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
