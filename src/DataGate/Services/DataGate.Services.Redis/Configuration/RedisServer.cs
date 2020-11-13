namespace DataGate.Services.Redis
{
    using System;
    using System.Diagnostics;

    public static class RedisServer
    {
        public static void Run()
        {
            var process = new Process();
            process.StartInfo.FileName = "C:\\redis-server-launch.bat";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += (sender, data) => {
                Console.WriteLine(data.Data);
            };
            var started = process.Start();

            //process.HasExited()
        }
    }

}
