using Ant_3_Arena.Ants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Drawing;
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
                .ConfigureServices((hc, services) =>
                {
                    Size screenSize = new Size(800, 450); // match setuped in the AntArena.Designer.cs ln 45

                    services.AddSingleton<AntArena>();
                    services.AddTransient((s) =>
                    {
                        return new AntBlack(screenSize);
                    });
                    services.AddTransient((s) =>
                    {
                        return new AntRed(screenSize);
                    });
                    services.AddTransient((s) =>
                    {
                        return new AntYellow(screenSize);
                    });
                });
        }
    }
}
