using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Function
{
    public static class DependencyRegistrations
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                    .AddSingleton<FunctionHandler>();

            return services.BuildServiceProvider();
        }
    }
}