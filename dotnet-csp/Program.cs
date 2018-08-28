using DotnetCsp.App.Business;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Consoler;

namespace dotnet_csp
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            var provider = new ServiceCollection()
                        .AddBusiness()
                        .BuildServiceProvider();
            var control = provider.GetService<PackageControl>();
            var consoleControl = new ConsoleControl();

            // temp test --
            //await control.InstallAsync("netcore.angular");
            // ---

            ConsoleOption packageName;
            consoleControl.AddCommand(new ConsoleCommand("add") {
                Description = "Add a new package",
                Options = new ConsoleOption[] {
                    packageName = new ConsoleOption("package name", "", "")
                },
                OnRunAsync = async () => await control.InstallAsync(packageName.Value)
            });

            await consoleControl.ComputeAsync(args);

        }

    }
}
