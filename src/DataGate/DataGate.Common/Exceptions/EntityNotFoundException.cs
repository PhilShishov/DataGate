// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Common.Exceptions
{
    using System;

    public class EntityNotFoundException : ArgumentException
    {
        private const string DefaultMessage = "The required entity was not found.";

        public EntityNotFoundException()
            : base(DefaultMessage)
        {
        }

        public EntityNotFoundException(string entityName)
            : base(string.Format(ErrorMessages.NotFoundEntity, entityName))
        {
        }

        public EntityNotFoundException(string message, string entityName)
            : base(message, entityName)
        {
        }
    }
}
