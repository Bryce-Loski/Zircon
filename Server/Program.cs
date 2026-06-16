using Library;
using Server.Envir;
using System;
using System.Reflection;
using System.Runtime;
using System.Windows.Forms;

namespace Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var assembly = Assembly.GetAssembly(typeof(Config));
            ConfigReader.Load(assembly);

            Config.LoadVersion();

            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new SMain());

            ConfigReader.Save(typeof(Config).Assembly);
        }

    }
}
