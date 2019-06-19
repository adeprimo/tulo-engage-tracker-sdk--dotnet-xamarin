# Tulo Engage Tracker SDK for Xamarin

This is the tracker for .NET Core with Xamarin support.

## Distributing updates to the library

* The library is distributed as a "nuget" package on the official public nuget source feed.
* We have an organization on Nuget called "Tulo-Engage" which is where we publish the official packages.
* In order to publish a new version of the library a new nuget package needs to be pushed upstream.

*A nuget package is created like so:*

```bash
$ dotnet pack
Microsoft (R) Build Engine version 16.1.76+g14b0a930a7 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 41.02 ms for /Users/mange/Projects/Wot/repos/engage-tracker-sdk-xamarin/Tulo.Engage.Tracker.Sdk.Xamarin.CLI/Tulo.Engage.Tracker.Xamarin.CLI.csproj.
  Restore completed in 41.02 ms for /Users/mange/Projects/Wot/repos/engage-tracker-sdk-xamarin/Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin/Adeprimo.Tulo.Engage.Tracker.SDK.Xamarin.csproj.
  Adeprimo.Tulo.Engage.Tracker.SDK.Xamarin -> /Users/mange/Projects/Wot/repos/engage-tracker-sdk-xamarin/Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin/bin/Debug/netstandard2.0/Adeprimo.Tulo.Engage.Tracker.SDK.Xamarin.dll
  Successfully created package '/Users/mange/Projects/Wot/repos/engage-tracker-sdk-xamarin/Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin/bin/Debug/Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.0.1.9-alpha.nupkg'
```

If package already exist it will not be created again.

### Publishing the package

```bash
dotnet nuget push <path to nuget package> -s https://api.nuget.org/v3/index.json -k {apikey}
```

The apikey is available in Lastpass (search 'nuget')
