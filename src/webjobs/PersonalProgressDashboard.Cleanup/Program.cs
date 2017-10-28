
using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Cleanup.Services;
using PersonalProgressDashboard.Common.Logging;
using System;

namespace PersonalProgressDashboard.Cleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var services = new ServiceCollection();
            var serviceProvider = startup.ConfigureServices(services);

            try
            {
                Console.WriteLine("started");
                var dataCleanup = serviceProvider.GetRequiredService<IDataCleanup>();
                dataCleanup.Process();
                Console.WriteLine("starting seed");
                var dataSeed = serviceProvider.GetRequiredService<IDataSeed>();
                dataSeed.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                LogHelper.Error($"----- Unexpected error occurred ----- : {ex.Message} ");
            }

#if DEBUG
            Console.WriteLine("completed");
            Console.ReadKey();
#endif
        }
    }
}
