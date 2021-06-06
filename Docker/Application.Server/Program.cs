using System;
using System.Data.SqlClient;
using System.IO;
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
            Console.WriteLine("Listen ({0}; {1})", prefix, "v1.03");

            // Env
            var target = EnvironmentVariableTarget.User;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                target = EnvironmentVariableTarget.Process;
            }
            var envText = Environment.GetEnvironmentVariable("MY", target);
            Console.WriteLine("ENV (MY={0})", envText);

            // Volume
            var fileNameVolume = "C:/Temp/Docker/data.txt";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                fileNameVolume = "/myshare/data.txt";
            }
            if (!File.Exists(fileNameVolume))
            {
                File.WriteAllText(fileNameVolume, "MyVolume");
            }

            // Listen
            int count = 0;
            while (true)
            {
                count += 1;
                var context = await listener.GetContextAsync();
                var response = context.Response;
                Console.WriteLine("Serve ({0})", context.Request.Url);
                var volumeText = File.ReadAllText(fileNameVolume);
                string sqlText;
                try
                {
                    var connection = new SqlConnection("Data Source=host.docker.internal,1434;Initial Catalog=master;User Id=sa;Password=Your_password123;Connection Timeout=1");
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT GETUTCDATE()", connection);
                    sqlText = command.ExecuteScalar().ToString();
                }
                catch (Exception exception)
                {
                    sqlText = exception.ToString();
                }
                var responseText = string.Format("Hello from .NET Core! (Count={0}; VolumeText={1}; SQL={2};)", count, volumeText, sqlText);
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
