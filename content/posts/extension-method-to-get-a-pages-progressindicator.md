+++
title = "Extension method to get a page's ProgressIndicator"
date = "2011-07-20T21:59:58Z"
categories = ["Code"]
tags = ["Microsoft", "Windows Phone"]
draft = false
+++

In Mango we added the ability to interact with the shell's native progress indicator along the top of the page. This is a great way to maintain UI consistency with the phone as well as get a smooth progress animation because the system is handling the animation vs. the Silverlight runtime. Here I'm recreating the 'save to phone' menu item you can see in the pictures hub by adding a "Saving picture..." progress indicator:

[![image](/images/image_thumb_4.png "image")](/images/image_4.png)

There are some great articles on using the new ProgressIndicator out there and I won't do yet another intro blog post but I did want to share a little extension method I wrote to grab it from the page and avoid some of the annoying initialization code that you end up writing over and over again.

Some of my favorite ProgressIndicator articles so far for those looking to explore this in more depth are:

- [Creating a global ProgressIndicator experience using the Windows Phone 7.1 SDK Beta 2](http://www.jeff.wilcox.name/2011/07/creating-a-global-progressindicator-experience-using-the-windows-phone-7-1-sdk-beta-2/)
- [Binding the WP7 ProgressIndicator in XAML](http://danielvaughan.org/post/Binding-the-WP7-ProgressIndicator-in-XAML.aspx)  

And here is my little extension method I've found useful on a few pages:

```csharp
public static class Extensions
{
    public static ProgressIndicator GetProgressIndicator(this PhoneApplicationPage page)
    {
        var progressIndicator = SystemTray.ProgressIndicator;
        if (progressIndicator == null)
        {
            progressIndicator = new ProgressIndicator();
            SystemTray.SetProgressIndicator(page, progressIndicator);
        }
        return progressIndicator;
    }
}
```

I'm playing with using some of the various code snippet websites out there and this is embedded from [Smipple](http://www.smipple.net/snippet/Shawn%20Oster/GetProgressIndicator%20extension%20method). I'd love to see more Windows Phone snippets pop up on these sites.

**UPDATE:** Scratch the idea of embedding Smipple snippets via embed code, it looks awesome but seems to tweak my formatting, going back to good old syntax highlighted.
