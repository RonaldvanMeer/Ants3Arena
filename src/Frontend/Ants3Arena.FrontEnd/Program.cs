using Ant3Arena.Business.Ants;
using Ant3Arena.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                    int nrOfAntsByColor = 3; // can be configurable with appsettings.json and read via hc.Configuration

                    services.AddSingleton<AntArena>();

                    services.AddSingleton(provider =>
                    {
                        IEnumerable<IAnt> blackAnts = Enumerable.Range(0, nrOfAntsByColor).Select(_ => new AntBlack(screenSize));
                        IEnumerable<IAnt> redAnts = Enumerable.Range(0, nrOfAntsByColor).Select(_ => new AntRed(screenSize));
                        IEnumerable<IAnt> yellowAnts = Enumerable.Range(0, nrOfAntsByColor).Select(_ => new AntYellow(screenSize));
                        IEnumerable<IAnt> greenAnts = Enumerable.Range(0, nrOfAntsByColor).Select(_ => new AntWhite(screenSize));

                        return blackAnts.Concat(redAnts).Concat(yellowAnts).Concat(greenAnts).ToList();                        
                    });

                });
        }
    }
}
