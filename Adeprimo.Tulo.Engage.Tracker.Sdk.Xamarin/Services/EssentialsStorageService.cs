using System;
using Xamarin.Essentials;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services
{
    public class EssentialsStorageService : IStorageService
    {
        public string Get(string key, string defaultValue = "")
        {
            return Preferences.Get(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, bool value)
        {
            Preferences.Set(key, value);
        }
    }
}
