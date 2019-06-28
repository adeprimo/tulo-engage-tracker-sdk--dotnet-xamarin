using System;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models;

namespace Tulo.Engage.Tracker.Xamarin.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Engage Tracker sample app.");
            if (args.Length != 3)
            {
                Console.WriteLine("!! Please provide mandatory arguments for organisationId, productId and the eventUrl");
                Console.WriteLine("$ dotnet run <organisationId> <productId> <eventUrl>\n");
                Environment.Exit(0);
            }
            var organisationId = args[0];
            var productId = args[1];
            var eventUrl = args[2];

            EngageStorage storage = new EngageStorage(new MemoryStorageService());
            EngageApplication application = new EngageApplication(new CliApplicationService());

            var tracker = EngageTrackerBuilder.Build(organisationId, productId, eventUrl, storage, application);

            var user = new EngageUser
            {
                UserId = Util.GenerateGuid(),
                PaywayUserId = Util.GenerateGuid(),
                Products = new string[] { "product_1", "product_2" },
                LoggedIn = true,
                Position = new EngageUserLocation { Latitude = "10", Longitude = "20" },
            };

            tracker.SaveUser(user);
            var eventBuilder = new EngageEventBuilder(storage, application);

            var trackEvent = eventBuilder.Build("app:pageview");
            tracker.Track("/", trackEvent);

            var artEvent = eventBuilder.Build("app:article.read");
            tracker.Track("/", artEvent);

            var content = new EngageContent
            {
                State = "open",
                Type = "paid",
                ArticleId = Util.GenerateGuid(),
                Title = "Long title noone wants to read",
                Section = "Sport",
                Keywords = new string[] { "sport", "news" },
                AuthorId = new string[] { Util.GenerateGuid() },
                Location = new EngageArticleLocation { Latitude = "10", Longitude ="20"}
            };
            var purchaseEvent = eventBuilder.Build("app:article.purchase");
            purchaseEvent.Content = content;

            var newUser = new EngageUser
            {
                UserId = "other-user-id",
                PaywayUserId = "other-payway-id",
                Products = new string[] { "product_1", "product_2", "product_3" },
                LoggedIn = true,
                Position = new EngageUserLocation { Latitude = "10", Longitude = "20" },
            };
            purchaseEvent.User = newUser;

            var source = eventBuilder.Source();
            source.Browser.Name = "Test CLI";
            source.Locale.Language = "sv";
            source.Locale.TimeZoneOffset = "+1";
            purchaseEvent.Source = source;

            tracker.Track("/purchase", purchaseEvent);

        }
    }
}
