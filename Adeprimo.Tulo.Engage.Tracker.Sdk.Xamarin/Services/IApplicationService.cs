using System;
namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services
{
    public interface IApplicationService
    {
        bool IsFirstLaunch { get; }
        (double width, double height) DeviceResolution { get; }
        string AppVersionName { get; }
        string AppVersionCode { get; }
        string AppName { get; }
        string UserAgent { get; }
        string OsName { get; }
        int ColorDepth { get; }
        string Language { get; }
        string TimezoneOffset { get; }
    }
}
