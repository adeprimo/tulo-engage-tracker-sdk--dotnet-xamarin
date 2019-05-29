using System;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Tulo.Engage.Tracker.Xamarin.CLI
{
    public class CliApplicationService : IApplicationService
    {

        public bool IsFirstLaunch => true;

        public (double width, double height) DeviceResolution => (double.Parse("80"), double.Parse("25"));

        public string AppVersionName => "1.0.0";

        public string AppVersionCode => "100";

        public string AppName => "Xamarin Cli sample";

        public string UserAgent => "Cli (dotnet)";

        public string OsName => "MacOS 10.14";

        public int ColorDepth => 0;
        public string Language => "sv";
        public string TimezoneOffset => "1";
    }
}
