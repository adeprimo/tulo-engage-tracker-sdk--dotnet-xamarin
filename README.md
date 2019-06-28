# Tulo Engage Tracker SDK for Xamarin

This is the tracker SDK for .NET Core with Xamarin support, use this SDK if you want to track events in Tulo Engage using C# and Xamarin. The SDK could also be used in plain C# projects by implementing non-Xamarin specific helper classes, more about that further down.

## Installation

The SDK is distributed as a [Nuget package](https://www.nuget.org/packages/Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin), install using normal procedures.

## Usage

### Permissions

The tracker needs network access to be able to send any events to Tulo Engage.

### Setup

In order to start sending events you need to initialize the tracker, you can do this with the "EngageTrackerBuilder" like so:

#### Building a tracker with default configuration

```
// using standard configuration
var tracker = EngageTrackerBuilder.Build("organisationId", "productId", "eventUrl");
```

#### Building a tracker with specific Application and Storage-services

```
// using your own implementation for "IApplicationService" and "IStorageService" when not using Xamarin.
var tracker = EngageTrackerBuilder.Build("organisationId", "productId", "eventUrl", applicationService, storageService);
```

After initialization the tracker can either be saved as a singleton or you can retrieve the tracker using the "EngageTrackerBuilder".

```
 var tracker = EngageTrackerBuilder.GetInstance();
```

#### Configuration

Contact Adeprimo for the following configuration parameters:

* organisationId
* productId
* eventUrl

### Sending events

It is recommended that events are created using the "EventBuilder" in the tracker.

#### Creating an event and send it

```
 // create a pageview-event
 // eventPrefix defaults to "app"
 // eventVersion defaults to "1"
 var trackEvent = EngageTrackerBuilder.GetInstance().EventBuilder.Build("pageview");
 EngageTrackerBuilder.GetInstance().Track("/", trackEvent); // path => pageName in app


 // create a pageview-event
 // eventPrefix is set to "browser"
 // eventVersion defaults to "1"
 trackEvent = EngageTrackerBuilder.GetInstance().EventBuilder.Build("pageview", eventPrefix="browser");
 EngageTrackerBuilder.GetInstance().Track("/", trackEvent);

 // create a pageview-event
 // eventPrefix defaults to "app"
 // eventVersion is set to "APP_1"
 trackEvent = EngageTrackerBuilder.GetInstance().EventBuilder.Build("pageview", eventTypeVersion="APP_1");
 EngageTrackerBuilder.GetInstance().Track("/", trackEvent);
```

An event created with the "EventBuilder" in tracker will decorate the event with default values and values fetched from the configured IApplicationService, in this case the Xamarin.Essentials implementation.

#### Decorating an event further

```
 // set content data for an article being read.
 var builder = EngageTrackerBuilder.GetInstance().EventBuilder;
 var trackEvent = builder.Build("pageview");
 var content = new EngageContent
 {
    State = "open",
    Type = "paid",
    ArticleId = "the-article-id",
    Title = "Long title noone wants to read",
    Section = "Sport",
    Keywords = new string[] { "sport", "news" },
    AuthorId = new string[] { "an-author-id" },
    Location = new EngageArticleLocation { Latitude = "10", Longitude ="20"}
 };
 trackEvent.Content = content;

 // add user information
 var user = new EngageUser
 {
    UserId = "other-user-id",
    PaywayUserId = "other-payway-id",
    Products = new string[] { "product_1", "product_2", "product_3" },
    LoggedIn = true,
    Position = new EngageUserLocation { Latitude = "10", Longitude = "20" },
 }
 trackEvent.User = user;

 // add custom source information
var source = builder.Source(); // This will create a new "source" object and prefill with defaults, which can be changed manually.
source.Browser.Name = "My app";
trackEvent.source = source;
EngageTrackerBuilder.GetInstance().Track("/", trackEvent);
```

### User information

User information is probably something you don't want to attach every time you send an event, instead you should "save" the user in the tracker upon initialization.

```
var currentUser = GetCurrentUser(); // Some method to get hold of logged in user
var tracker = EngageTrackerBuilder.Build("organisationId", "productId", "eventUrl");
tracker.SaveUser(new EngageUser{PaywayUserId = currentUser.PaywayId, UserId = currentUser.Id,  LoggedIn = true}):
```

Until the next time the user is saved, the above user will be used by the tracker automatically.

### Custom data

Some events needs to be decorated with custom data not directly exposed as a property on an Engage event. For example if you want to track which "product-filter" a specific pageview is using to retrieve data.

```
 var builder = EngageTrackerBuilder.GetInstance().EventBuilder;
 var trackEvent = builder.Build("pageview");
 trackEvent.EventCustomData = new { ProductFilter = "Apparel" };
 EngageTrackerBuilder.GetInstance().Track("/products" trackEvent);
```

### Modifying the default data

#### Application information

Collecting information about the APP being executed is implemented using the class "EngageApplication" which in turn uses an implementation of "IApplicationService" to fetch the information. In this SDK we have implemented the interface using [Xamarin Essentials](https://www.nuget.org/packages/Xamarin.Essentials) (AppInfo, DeviceDisplay, DeviceInfo, VersionTracking). In cases where you don't run Xamarin you need to develop your own implementation of IApplicationService and use that when configuring the tracker.

The project Tulo.Engage.Tracker.Sdk.Xamarin.CLI contains examples of this kind of implementation and setup.

#### Application storage

Storing data about the user and other properties that needs to be persisted, the tracker uses the class "EngageStorage" which in turn uses an implementation of "IStorageService" to handle the actual storing of data in the app. In this SDK we have implemented the interface using [Xamarin Essentials](https://www.nuget.org/packages/Xamarin.Essentials) (Xamarin.Essentials.Preferences). In cases where you don't run Xamarin you need to develop your own implementation of IStorageService and use that when configuring the tracker.

The project Tulo.Engage.Tracker.Sdk.Xamarin.CLI contains examples of this kind of implementation and setup.
