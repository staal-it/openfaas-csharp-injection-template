// Copyright (c) Erwin Staal 2019. All rights reserved.
// This class is used to build your dependency container

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
                    // This is where you inject your custom classes
                    .AddTransient<IInjectMe, InjectMe>()
                    // Do not remove this line or the function will no longer start. You can change the lifetime
                    .AddSingleton<FunctionHandler>();

            return services.BuildServiceProvider();
        }
    }
}