+++
title = "Getting SubSonic Setup in Visual Studio"
date = "2008-02-04T08:44:00Z"
categories = ["Code"]
tags = ["C#", "SubSonic"]
draft = false
+++

I'm a big fan of [SubSonic](http://subsonicproject.com/default.aspx), a ORM/DAL generator / utility belt of goodness. Like any tool there is a little configuration and setup you need to do to get everything rolling and while Rob Conery [has some great podcasts](http://subsonicproject.com/view/using-the-command-line-tool.aspx) on doing just this, sometimes you just need to remember that one little option vs. wanting to watch a 10 minute podcast again, regardless of how melodic and sweet are the dulcet tones of Mr. Conery's voice.

## 1. [Download](http://subsonicproject.com/) and Install SubSonic

Seems simple but hey, some people need to be told everything :)

## 2. Create SubSonic DAL as an external tool

Even though SubSonic supports Rails-style auto-gen of your DAL via build providers I like putting my model/DAL in a separate class library and sadly build providers don't play well with class libraries.

Go to Tools ' Externals Tools... click "Add" and make it look like this:

[![External Tools](/images/ExternalTools_thumb.png)](/images/ExternalTools.png)

* That command is your path to **sonic.exe**
* If you're working with the MVC Toolkit (and why aren't you?) then change "App_CodeGenerated" to "ModelsGenerated"

## 3. Create SubSonic DB as an external tool

SubSonic can also version and script your database, very useful for source control and distributing your application. Same as above but make it look like this:

[![External Tools (2)](/images/ExternalTools2_thumb.png)](/images/ExternalTools2.png)

## 4. Install SubSonic Schema

I dislike any warnings during a build and one you'll get with SubSonic is it not knowing about the SubSonic config sections.  I did a [blog post on how to fix this](/about/#search=SubSonic) awhile back but I'm repeating here for the lazy (like myself):

1. Download [SubSonicSchema.xsd](/SubSonicSchema.xsd) (if you right-click to download make sure you save it with an xsd extension)
1. Put it in C:Program FilesMicrosoft Visual Studio 8.0XmlSchemas (adjust accordingly for VS2008)
1. Edit DotNetConfig.xsd in the same folder and add the following line:

    ```xml
    <xs:include schemalocation="SubSonicSchema.xsd" />
    ```

    (I added it right underneath the `<xs:schema>` opening tag, seems to work. Also, if you're using **Vista** you'll need to edit `DotNetConfig.xsd` in an editor that was started with right-click, Admin, otherwise it'll write a copy of the xsd into the Virtual Store and your changes will never take effect. Trust me, I learned this the hard way.)

1. Close Visual Studio if it's running, re-open, ta-da you now have IntelliSense as well as no more annoying _"Could not find schema information for..."_ messages.

## 5. Install SubSonic code snippets

You add various sections into your web.config to wire up the magic and nothing is more boring than typing the same poop over and over again. I created some snippets that provide the various bits that you can download here (actually not quite yet since the bits are at work and my VPN is broken right now).

And Bob's your Uncle, you have all the boring schtuff out of the way and now you're ready to start genning ya some code. If you don't actually know how to start genning your code then I'd suggest watching some of those screencasts I mentioned above.
