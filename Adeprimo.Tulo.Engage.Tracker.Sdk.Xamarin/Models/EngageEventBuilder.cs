using System;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageEventBuilder
    {
        readonly EngageStorage _storage;
        readonly EngageApplication _application;

        public EngageEventBuilder()
        {
            _storage = new EngageStorage(new EssentialsStorageService());
            _application = new EngageApplication(new EssentialsApplicationService());
        }

        public EngageEventBuilder(EngageStorage storage, EngageApplication application)
        {
            _storage = storage;
            _application = application;
        }
        public EngageEvent Build(string eventName, string eventPrefix="app", string eventTypeVersion="1")
        {
            return new EngageEvent($"{eventPrefix}:{eventName}", _storage.RootEventId, _storage.ClientId, eventTypeVersion);
        }

        public EngageSource Source(string path="")
        {
            return new EngageSource
            {
                Url = new EngageUrl(path),
                Browser = Browser(),
                Screen = Screen(),
                Locale = Locale()
            };
        }

        public EngageBrowser Browser()
        {
            return new EngageBrowser
            {
                Name = _application.AppName,
                Platform = _application.OsName,
                Ua = _application.UserAgent,
                Version = $"{_application.AppVersionName} ({_application.AppVersionCode})"
            };
        }

        public EngageScreen Screen()
        {
            (double width, double height) = _application.DeviceResolution;
            return new EngageScreen
            {
                Height = height.ToString(),
                Width = width.ToString(),
                ColorDepth = _application.ColorDepth
            };
        }

        public EngageLocale Locale()
        {
            return new EngageLocale
            {
                Language = _application.Language,
                TimeZoneOffset = _application.TimezoneOffset
            };
        }
    }
}
