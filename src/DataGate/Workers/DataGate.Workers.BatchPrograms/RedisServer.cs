// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Workers.BatchPrograms
{
    using System;
    using System.Diagnostics;

    using DataGate.Workers.BatchPrograms.Contracts;
    using DataGate.Workers.Common;

    public class RedisServer : IExecutor
    {
        public void Execute(string dirPath)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = $"{dirPath}\\batch\\{FileNames.RedisServerBatch}";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;

                process.StartInfo.RedirectStandardError = true;
                process.Start();

                Console.WriteLine(process.StandardError.ReadToEnd());
            }
        }
    }
}
