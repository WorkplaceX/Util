using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;

namespace Application.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World! From Cli v1.12");

                // Env
                var target = EnvironmentVariableTarget.User;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    target = EnvironmentVariableTarget.Process;
                }
                var envText = Environment.GetEnvironmentVariable("MY", target);
                Console.WriteLine("ENV (MY={0})", envText);

                // Database create
                var connectionString = "Data Source=host.docker.internal,1433;Initial Catalog=master;User Id=sa;Password=Your_password123;";
                Console.WriteLine("Create database Application");
                SqlConnection connection = new SqlConnection(connectionString);
                var command = new SqlCommand("CREATE DATABASE Application", connection);
                Thread.Sleep(60000); // 1min
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Create database Application DONE");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
