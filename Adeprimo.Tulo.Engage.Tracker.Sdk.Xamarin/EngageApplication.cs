using System;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin
{
    public class EngageApplication
    {
        readonly IApplicationService _applicationService;

        public EngageApplication(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public bool IsFirstLaunch => _applicationService.IsFirstLaunch;
        public (double width, double height) DeviceResolution => _applicationService.DeviceResolution;
        public string AppName => _applicationService.AppName;
        public string AppVersionName => _applicationService.AppVersionName;
        public string AppVersionCode => _applicationService.AppVersionCode;
        public string UserAgent => _applicationService.UserAgent;
        public string OsName => _applicationService.OsName;
        public int ColorDepth => _applicationService.ColorDepth;
        public string Language => _applicationService.Language;
        public string TimezoneOffset => _applicationService.TimezoneOffset;

    }
}
