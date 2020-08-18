using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using QRCode.Bootstrap;
using QRCode.Common.Enums;
using QRCode.Service;

namespace QRCode.App
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting app...");

            // Register app dependencies
            //TODO: add logger
            var serviceProvider = new ServiceCollection()
                .AddAppDependencies()
                .BuildServiceProvider();

            // Validate parameters
            // Expecting 1 required parameter to be passed (file path)
            if (args.Length != 1)
            {
                Console.WriteLine($"ERROR: Invalid argument count: {args.Length}");
                return;
            }

            var service = serviceProvider.GetService<IQRScannerService>();

            try
            {
                Console.WriteLine($"Trying to scan file:\n {args[0]}");

                var (status, result) = await service.ScanQRCodeAsync(args[0]);

                var output = status == OperationStatus.Success
                    ? $"Success \nResult :::\n {result}"
                    : $"Error: \n {status}";

                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR ::: {e.Message}");
                //TODO: log error
            }


            Console.ReadKey();
        }
    }
}
