# OpenFaaS C# Dependency Injection Template

This template for OpenFaaS allows you to use dependency injection in your function.

```
$ faas template pull https://github.com/staal-it/openfaas-csharp-injection-template
$ faas new --list
Languages available as templates:
- csharp-injection

```

This template uses the default dependency provider from Microsoft.Extensions.DependencyInjection.

## Using the template
First, pull the template with the faas CLI and create a new function:

```
$ faas-cli template pull https://github.com/staal-it/openfaas-csharp-injection-template
$ faas-cli new --lang csharp-injection <function name>
```

In the directory that was created, using the name of you function, you'll find `DependencyRegistrations.cs`. This is where you can register your dependencies. Here's an example:

``` csharp
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
```

Once you have registered your injectables in this file your will be able to inject them into `FunctionHandler.cs` like this:

``` csharp
using System;
using System.Text;

namespace Function
{
    public class FunctionHandler
    {
        private IInjectMe _injectMe;

        public FunctionHandler(IInjectMe injectMe)
        {
            _injectMe = injectMe;
        }

        public string Handle(string input) {
            return _injectMe.SayHello(input);
        }
    }
}
```