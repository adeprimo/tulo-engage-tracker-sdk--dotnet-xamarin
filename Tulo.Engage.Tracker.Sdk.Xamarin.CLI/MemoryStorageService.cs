using System;
using System.Collections.Generic;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Tulo.Engage.Tracker.Xamarin.CLI
{
    public class MemoryStorageService : IStorageService
    {
        Dictionary<string, object> _cache;
        public MemoryStorageService()
        {
            _cache = new Dictionary<string, object>();
        }

        public string Get(string key, string defaultValue = "")
        {
            if (_cache.ContainsKey(key))
                return (string)_cache[key];
            return defaultValue;
        }

        public bool Get(string key, bool defaultValue)
        {
            if (_cache.ContainsKey(key))
                return (bool)_cache[key];
            return defaultValue;
        }

        public void Set(string key, string value)
        {
            if (_cache.ContainsKey(key))
                _cache[key] = value;
            else
                _cache.Add(key, value);
        }
        public void Set(string key, bool value)
        {
            if (_cache.ContainsKey(key))
                _cache[key] = value;
            else
                _cache.Add(key, value);
        }
    }
}
