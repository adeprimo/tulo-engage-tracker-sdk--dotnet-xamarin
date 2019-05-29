using System;
using Newtonsoft.Json;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin
{
    public class EngageStorage
    {
        static readonly string PREF_KEY_OPTOUT = "tulo.engage.tracker.optout";
        static readonly string PREF_KEY_CLIENT_ID = "tulo.engage.tracker.clientid";
        static readonly string PREF_KEY_SESSION_ID = "tulo.engage.tracker.sessionid";
        static readonly string PREF_KEY_ROOT_EVENT_ID = "tulo.engage.tracker.rooteventid";
        static readonly string PREF_KEY_USER = "tulo.engage.tracker.user";

        readonly IStorageService _storageService;


        public EngageStorage(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public bool OptOut => _storageService.Get(PREF_KEY_OPTOUT, false);

        public string SessionId
        {
            get
            {
                var sessionId = _storageService.Get(PREF_KEY_SESSION_ID, "");
                if (string.IsNullOrEmpty(sessionId))
                {
                    throw new ApplicationException("FATAL: Session not started");
                }
                return sessionId;
            }
            set
            {
                _storageService.Set(PREF_KEY_SESSION_ID, value);
            }
        }

        public string RootEventId
        {
            get
            {
                return _storageService.Get(PREF_KEY_ROOT_EVENT_ID, "");
            }
            set
            {
                _storageService.Set(PREF_KEY_ROOT_EVENT_ID, value);
            }
        }


        public string ClientId
        {
            get
            {
                var clientId = _storageService.Get(PREF_KEY_CLIENT_ID, "");
                return clientId;
            }
            set
            {
                _storageService.Set(PREF_KEY_CLIENT_ID, value);
            }
        }

        public EngageUser User
        {
            get
            {
                var user = _storageService.Get(PREF_KEY_USER, "");
                if (string.IsNullOrEmpty(user))
                    return null;
                return JsonConvert.DeserializeObject<EngageUser>(user);
            }
            set
            {
                _storageService.Set(PREF_KEY_USER, value.ToJson());
            }
        }

    }
}
