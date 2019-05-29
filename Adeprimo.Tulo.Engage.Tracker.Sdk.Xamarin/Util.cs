using System;
namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin
{
    public static class Util
    {
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static void LogInfo(string message)
        {
            Console.WriteLine($"[ENGAGE][INFO] {message}");
        }

        public static void LogError(string message)
        {
            Console.WriteLine($"[ENGAGE][ERROR] {message}");
        }
    }
}
