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

            //using (var process = new Process())
            //{
            //   

            //    var memoryTaskCancellationToken = new CancellationTokenSource();
            //    var memoryTask = Task.Run(
            //        () =>
            //        {
            //            while (true)
            //            {
            //                try
            //                {
            //                    if (process.HasExited)
            //                    {
            //                        return;
            //                    }
            //                    executionResult.MemoryUsed = Math.Max(executionResult.MemoryUsed, process.PeakWorkingSet64);
            //                }
            //                catch (InvalidOperationException)
            //                {
            //                    return;
            //                }

            //                if (memoryTaskCancellationToken.IsCancellationRequested)
            //                {
            //                    return;
            //                }

            //                Thread.Sleep(TimeIntervalBetweenTwoMemoryConsumptionRequests);
            //            }
            //        },
            //        memoryTaskCancellationToken.Token);

            //    string error = string.Empty;
            //    if (!string.IsNullOrEmpty(input))
            //    {
            //        try
            //        {
            //            await process.StandardInput.WriteLineAsync(input);
            //            await process.StandardInput.FlushAsync();
            //            process.StandardInput.Close();
            //        }
            //        catch (IOException)
            //        {
            //            error = ReadingDataFromConsoleIsRequired;
            //        }
            //    }

            //    bool exited = process.WaitForExit(timeLimit);

            //    if (!exited)
            //    {
            //        if (!process.HasExited)
            //        {
            //            process.KillTree();
            //        }
            //    }

            //    // Close the memory consumption check thread
            //    memoryTaskCancellationToken.Cancel();

            //    string output = await process.StandardOutput.ReadToEndAsync();
            //    error += await process.StandardError.ReadToEndAsync();

            //    executionResult.Error = error;
            //    executionResult.Output = output.Trim();
            //    executionResult.ExitCode = process.ExitCode;
            //    executionResult.TimeWorked = process.ExitTime - process.StartTime;
            //    executionResult.PrivilegedProcessorTime = process.PrivilegedProcessorTime;
            //    executionResult.UserProcessorTime = process.UserProcessorTime;

            //    //We need to check first if there is runtime error because it is with more priority
            //    if (!string.IsNullOrEmpty(executionResult.Error))
            //    {
            //        executionResult.Type = ProcessExecutionResultType.RunTimeError;
            //    }
            //    else if (executionResult.TimeWorked.TotalMilliseconds >= timeLimit)
            //    {
            //        executionResult.Type = ProcessExecutionResultType.TimeLimit;
            //    }
            //    else if (executionResult.MemoryUsed >= memoryLimit)
            //    {
            //        executionResult.Type = ProcessExecutionResultType.MemoryLimit;
            //    }

            //    return executionResult;
            //}
        }
    }
}
