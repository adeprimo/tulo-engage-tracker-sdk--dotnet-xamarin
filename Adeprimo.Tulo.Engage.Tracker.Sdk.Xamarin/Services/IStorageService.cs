using System;
namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services
{
    public interface IStorageService
    {
        void Set(string key, string value);
        void Set(string key, bool value);
        string Get(string key, string defaultValue = "");
        bool Get(string key, bool defaultValue = false);
    }
}
