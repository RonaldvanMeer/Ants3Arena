using Ant3Arena.Business;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateDefaultHostBuilder().Build();
            Application.Run(host.Services.GetRequiredService<AntArena>());
        }

        static IHostBuilder CreateDefaultHostBuilder()
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddBusinessDependencies();
                    services.AddSingleton<AntArena>();
                });
        }
    }
}
