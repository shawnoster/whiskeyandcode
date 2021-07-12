+++
title = "Using RestSharp with AgFx in your Windows Phone app"
date = "2012-02-15T02:16:17Z"
categories = ["Code"]
tags = ["Microsoft", "Windows Phone", "REST", "RestSharp", "AgFx"]
draft = false
+++

I'm using the excellent REST library [RestSharp](http://restsharp.org) for all my REST and OAuth calls. I'm also using the amazing data caching framework [AgFx](http://agfx.codeplex.com/) written by Shawn Burke which handles caching your web requests, something that goes from a nice to have to critical when writing high performance Windows Phone apps.

Out of the box AgFx handles all your requests so it can do it's caching thing, getting in the front of each request to determine if it should give you a cached version instead of hitting the web, if it should invalidate the cache, if it should give you a cached version and then make a live request, etc. This is how you want it but sometimes you want more control over how those live requests are made. In my case I'm using OAuth and requesting protected resources that require OAuth access tokens and RestSharp has some very nice methods for both authenticating and making those pesky protected calls. The question is how to slip RestSharp into the middle of the AgFx mechanism?

## AgFx Out of the Box

Your basic AgFx call looks like this:

```csharp
ZipCodeVm viewModel = DataManager.Current.Load<ZipCodeVm>(txtZipCode.Text);
```

Which eventually executes code like this (which you the developer has written):

```csharp
public LoadRequest GetLoadRequest(ZipCodeLoadContext loadContext, Type objectType)
{
    // build the URI, return a WebLoadRequest.
    string uri = String.Format(ZipCodeUriFormat, loadContext.ZipCode);
    return new WebLoadRequest(loadContext, new Uri(uri));
}
```

AgFx will call GetLoadRequest() to get a LoadRequest which it'll use when it needs to fetch live data. This example is using the default WebLoadRequest which uses HttpWebRequest under the covers to fetch the data but as long as you return an object that descends from LoadRequest you can use whatever requesting mechanism you like.

## RestSharpLoadRequest

That's where RestSharp comes in. Instead of hand-crafting HTTP requests including hand-crafting headers and building POST payloads I'm going to let RestSharp do the heavy lifting by creating a custom RestSharpLoadRequest. It's based heavily on the WebLoadRequest in AgFX, right down to the comments and took all of 15 minutes to code up. It's not that exciting of a class but you can download it and view it on github as a gist:

[An AgFx LoadRequest that uses RestSharp to make the actual request, supports passing in OAuth tokens](https://gist.github.com/1832559)

[Download it](https://gist.github.com/gists/1832559/download) and drop it into your application as is (well, I'd probably change the namespace to something more appropriate). Sorry about it being a tar.gz file, maybe I'll ping [Phil Haack](http://haacked.com/) now that he works there to offer up .zips for gists as well.

**WOW**, sorry folks, I didn't realize I'd created the Gist as private, if you tried to view it before you should have better luck now.

## RestSharpLoadRequest in Action

I'm going straight to a meaty example where I create a few parameters to throw on the URL and pass in all my OAuth token goodness:

```csharp
public LoadRequest GetLoadRequest(ShelfLoadContext loadContext, Type objectType)
{
    var resource = BuildResource(
        "review/list.xml",
        new Dictionary<string string ,>()
        {
            {"v", "2"},
            {"id", loadContext.UserId},
            {"page", loadContext.Page.ToString()},
            {"shelf", loadContext.Shelf}
        });

    return new RestSharpLoadRequest(
        loadContext,
        resource,
        Client.Current.ConsumerKey,
        Client.Current.ConsumerSecret,
        Client.Current.AccessToken,
        Client.Current.AccessTokenSecret);
}
```

Don't worry about the BuildResource call, that's simply building up your REST API end-point (aka "resource"). The only difference from the standard usage of AgFx is instead of a WebLoadRequest I'm using RestSharpLoadRequest.

And there you have it, now you can lean on RestSharp inside of the AgFx framework. Also If you're using [Hammock](https://github.com/danielcrenna/hammock) as your REST library as choice it should take all of 15 minutes to whip up a HammockLoadRequest following the same basic principles.

**UPDATE (02.14.2010):** The way I was handing parameters above was just plain weird, the RestRequest object that I'm using inside of RestSharpLoadRequest already has robust AddParameter() logic so I exposed it. The above code now looks like this:

```csharp
public override LoadRequest GetLoadRequest(ShelfLoadContext loadContext, Type objectType)
{
    var request = new RestSharpLoadRequest(
        loadContext,
        GoodReadsClient.Current.BuildResource("review/list.xml"),
        GoodReadsClient.Current.ConsumerKey,
        GoodReadsClient.Current.ConsumerSecret,
        GoodReadsClient.Current.AccessToken,
        GoodReadsClient.Current.AccessTokenSecret);

    request.AddParameter("key", GoodReadsClient.Current.ConsumerKey);
    request.AddParameter("shelf", loadContext.Shelf);
    request.AddParameter("v", "2");
    request.AddParameter("id", loadContext.UserId);
    request.AddParameter("page", loadContext.Page.ToString());

    return request;
}
```

Not only does it leverage existing code it follows the pattern most RestSharp/Hammock users are used to, namely you create the request and then you add on parameters.
