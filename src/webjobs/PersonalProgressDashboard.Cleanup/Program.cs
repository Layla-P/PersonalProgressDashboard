
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
                var dataCleanup = serviceProvider.GetRequiredService<IDataCleanup>();
                dataCleanup.Process();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"----- Unexpected error occurred ----- : {ex.Message} ");
            }

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
