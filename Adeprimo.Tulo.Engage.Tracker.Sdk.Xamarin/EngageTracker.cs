using System;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin
{
    public class EngageTracker
    {
        readonly string _organisationId;
        readonly string _productId;
        readonly string _eventUrl;
        string _url = "/";
        readonly Dispatcher _dispatcher;
        readonly EngageStorage _storage;
        readonly EngageApplication _application;
        readonly EngageEventBuilder _eventBuilder;

        public EngageTracker(string organisationId, string productId, string eventServiceUrl, EngageStorage storage=null, EngageApplication application=null)
        {
            _organisationId = organisationId;
            _productId = productId;
            _eventUrl = eventServiceUrl;
            _dispatcher = new Dispatcher(_eventUrl);
            _storage = storage ?? new EngageStorage(new EssentialsStorageService());
            _application = application ?? new EngageApplication(new EssentialsApplicationService());
            _eventBuilder = new EngageEventBuilder(_storage, _application);
            Initialize();
        }

        public EngageEventBuilder EventBuilder => _eventBuilder;

        public void SaveUser(EngageUser user)
        {
            _storage.User = user;
        }

        public void Track(string path, EngageEvent trackEvent)
        {
            if (path != null && _url != path)
            {
                NewRootEventId();
                trackEvent.RootEventId = _storage.RootEventId;
                _url = path;
            }
            else
            {
                trackEvent.RootEventId = _storage.RootEventId;
            }
            trackEvent.SessionId = _storage.SessionId;
            trackEvent.Context = new EngageContext(_organisationId, _productId);
            var user = _storage.User;
            if (user != null && trackEvent.User == null)
                trackEvent.User = user;

            if (trackEvent.Source == null)
            {
                trackEvent.Source = _eventBuilder.Source(path);
            }
                
            if (trackEvent.Source.Url == null)
                trackEvent.Source.Url = new EngageUrl(path);
            if (string.IsNullOrEmpty(trackEvent.Source.Url.PathName))
                trackEvent.Source.Url.PathName = path;

            if (trackEvent.Source.Browser == null)
                trackEvent.Source.Browser = _eventBuilder.Browser();
            if (trackEvent.Source.Screen == null)
                trackEvent.Source.Screen = _eventBuilder.Screen();
            if (trackEvent.Source.Locale == null)
                trackEvent.Source.Locale = _eventBuilder.Locale();



            _dispatcher.Send(trackEvent);

        }

        public string RootEventId => _storage.RootEventId;

        void Initialize()
        {
            NewRootEventId();
            StartSession();
            var clientId = _storage.ClientId;
            if (string.IsNullOrEmpty(clientId))
            {
                _storage.ClientId = Util.GenerateGuid();
            }
        }

        void StartSession()
        {
            _storage.SessionId = Util.GenerateGuid();
        }

        void NewRootEventId()
        {
            _storage.RootEventId = Util.GenerateGuid();
        }


    }
}
