using System;
using Xamarin.Essentials;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services
{
    public class EssentialsApplicationService : IApplicationService
    {
        // @todo add VersionTracking in application
        public bool IsFirstLaunch => VersionTracking.IsFirstLaunchEver;

        public string AppName => AppInfo.Name;
        public string AppVersionCode => AppInfo.BuildString;
        public string AppVersionName => AppInfo.VersionString;
        public (double width, double height) DeviceResolution => (DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height);

        public string OsName => DeviceInfo.Platform.ToString();
        public string UserAgent 
        {
            get
            {
                var ua = $"{AppName}/{AppVersionCode} ({DeviceInfo.Model}; {AppVersionName})";
                return ua;
            }
        }

        public int ColorDepth => 0;
        public string Language => "unknown";
        public string TimezoneOffset => "unknown";

    }
}
