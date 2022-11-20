using p5rpc.lib.Configuration;
using Reloaded.Mod.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib
{
    internal class Utils
    {
        private static ILogger _logger;
        private static Config _config;
        internal static nint BaseAddress { get; private set; }


        internal static void Initialise(ILogger logger, Config config)
        {
            _logger = logger;
            _config = config;
            using var thisProcess = Process.GetCurrentProcess();
            BaseAddress = thisProcess.MainModule!.BaseAddress;
        }

        internal static void LogDebug(string message)
        {
            if (_config.DebugEnabled)
                _logger.WriteLine($"[P5R Library] {message}");
        }

        internal static void Log(string message)
        {
            _logger.WriteLine($"[P5R Library] {message}");
        }

        internal static void LogError(string message, Exception e)
        {
            _logger.WriteLine($"[P5R Library] {message}: {e.Message}", System.Drawing.Color.Red);
        }

        internal static void LogError(string message)
        {
            _logger.WriteLine($"[P5R Library] {message}", System.Drawing.Color.Red);

        }

        /// <summary>
        /// Gets the address of a global from something that references it
        /// </summary>
        /// <param name="ptrAddress">The address to the pointer to the global (like in a mov instruction or something)</param>
        /// <returns>The address of the global</returns>
        internal static unsafe nuint GetGlobalAddress(nuint ptrAddress)
        {
            return (nuint)(*(int*)ptrAddress) + ptrAddress + 4;
        }
    }
}
