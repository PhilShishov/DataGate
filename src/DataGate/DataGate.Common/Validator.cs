// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Common
{
    using DataGate.Common.Exceptions;

    public static class Validator
    {
        public static void NotFoundExceptionIfEntityIsNull(object entity, string name)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException(name);
            }
        }
    }
}
