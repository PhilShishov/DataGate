namespace DataGate.Workers.BatchPrograms
{
    using System.Diagnostics;

    using DataGate.Workers.BatchPrograms.Contracts;

    public class RedisServer : IExecutor
    {
        public void Execute()
        {
            var process = new Process();
            process.StartInfo.FileName = "C:\\redis-server-launch.bat";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            //process.ErrorDataReceived += (sender, data) =>
            //{
            //    Console.WriteLine(data.Data);
            //};
            var started = process.Start();
        }
    }
}
