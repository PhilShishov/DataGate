// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Common
{
    using System;

    using DataGate.Common.Exceptions;

    public static class Validator
    {
        public static void EntityNotFoundException(object entity)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(entity));
            }
        }

        public static void ArgumentNullException(object entity, string message = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(message ?? nameof(entity));
            }
        }

        public static void ArgumentNullExceptionString(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ArgumentNullExceptionInt(int value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
