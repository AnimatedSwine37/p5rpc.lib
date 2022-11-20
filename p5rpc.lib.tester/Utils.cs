using Reloaded.Mod.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.tester
{
    internal class Utils
    {
        private static ILogger _logger;
        internal static nint BaseAddress { get; private set; }


        internal static void Initialise(ILogger logger)
        {
            _logger = logger;
            using var thisProcess = Process.GetCurrentProcess();
            BaseAddress = thisProcess.MainModule!.BaseAddress;
        }

        internal static void Log(string message)
        {
            _logger.WriteLine($"[P5R Library Tester] {message}");
        }

        internal static void LogError(string message, Exception e)
        {
            _logger.WriteLine($"[P5R Library Tester] {message}: {e.Message}", System.Drawing.Color.Red);
        }

        internal static void LogError(string message)
        {
            _logger.WriteLine($"[P5R Library Tester] {message}", System.Drawing.Color.Red);

        }
    }
}
