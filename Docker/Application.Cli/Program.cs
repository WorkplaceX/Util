using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Application.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! From Cli");

            // Env
            var target = EnvironmentVariableTarget.User;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                target = EnvironmentVariableTarget.Process;
            }
            var envText = Environment.GetEnvironmentVariable("MY", target);
            Console.WriteLine("ENV (MY={0})", envText);

            // Database create
            Console.WriteLine("Create database Application");
            SqlConnection connection = new SqlConnection("Data Source=localhost,1434; Initial Catalog=master; User Id=SA; Password=Your_password123;");
            connection.Open();
            var command = new SqlCommand("CREATE DATABASE Application", connection);
            command.ExecuteNonQuery();
        }
    }
}
