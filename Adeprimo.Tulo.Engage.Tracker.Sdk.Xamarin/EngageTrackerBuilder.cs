using System;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin
{
    public static class EngageTrackerBuilder
    {
        static EngageTracker _tracker;

        public static EngageTracker Build(string organisationId, string productId, string eventUrl, EngageStorage storage = null, EngageApplication application = null)
        {
            try
            {
                var url = new Uri(eventUrl);
            }
            catch(UriFormatException e)
            {
                throw new ApplicationException("FATAL: Invalid event url specified", e);
            }

            _tracker = new EngageTracker(organisationId, productId, eventUrl, storage, application);
            return _tracker;
        }

        public static EngageTracker GetInstance()
        {
            if (_tracker == null)
                throw new ApplicationException("FATAL: Tracker has not been initialized");
            return _tracker;
        }
    }
}
