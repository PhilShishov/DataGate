// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Workers.BatchPrograms.Contracts
{
    public interface IExecutor
    {
        void Execute(string dirPath);
    }
}
