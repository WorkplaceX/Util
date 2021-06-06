using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Application.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Host
            HttpListener listener = new HttpListener();
            var host = "localhost";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                host = "*";
            }
            var prefix = $"http://{ host }:8090/";
            listener.Prefixes.Add(prefix);
            listener.Start();
            Console.WriteLine("Listen ({0}; {1})", prefix, "v1.02");

            // Env
            var target = EnvironmentVariableTarget.User;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                target = EnvironmentVariableTarget.Process;
            }
            var envText = Environment.GetEnvironmentVariable("MY", target);
            Console.WriteLine("ENV (MY={0})", envText);

            // Listen
            int count = 0;
            while (true)
            {
                count += 1;
                var context = await listener.GetContextAsync();
                var response = context.Response;
                Console.WriteLine("Serve ({0})", context.Request.Url);
                var responseText = string.Format("Hello from .NET Core! ({0})", count);
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseText);
                response.ContentLength64 = buffer.Length;
                using (var output = response.OutputStream)
                {
                    output.Write(buffer, 0, buffer.Length);
                }
                response.Close();
            }
        }
    }
}
