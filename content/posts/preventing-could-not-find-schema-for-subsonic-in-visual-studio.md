+++
title = "Preventing \"Could not find schema...\" for SubSonic in Visual Studio"
date = "2007-08-18T09:05:00Z"
categories = ["Code"]
tags = ["Visual Studio", "SubSonic"]
draft = false
+++

My current favorite .NET DAL/ORM solution is [SubSonic](http://subsonicproject.com/). It strikes a good balance of being helpful without hindering, partly due to it being heavily inspired by Rails as well as the creator's focus not only on good code but good architecture and design. Another great thing about the project is that the creator, Rob Conery, does frequent screencasts explaining the nooks and crannies of SubSonic as well as writing informative, engaging and colorful posts over on [his blog](http://spook.wekeroad.com/).

Enough praise though, this post is all about fixing an "issue" that annoys me. SubSonic does part of it's magic through the SubSonicService, which is a custom configuration section in your web or app config. Since it's a custom section Visual Studio won't give you code completion (aka Intellisense) and it'll spit out a ton of "Could not find schema information for blahblahblah" warnings. These warning are basically saying, "I have no idea what this crap is in the web.config so you get no fancy Intellisense magic from me". To get back some of that magic here's all you have to do:

1. Download [SubSonicSchema.zip](/downloads/SubSonicSchema.zip) (if you right-click to download make sure you save it with an xsd extension)

2. Put it in `C:\Program Files\Microsoft Visual Studio 8.0\XmlSchemas`

3. Edit DotNetConfig.xsd in the same folder and add the following line:

    ```xml
    <xs:include schemaLocation="SubSonicSchema.xsd" />
    ```

    (I added it right underneath the `<xs:schema>` opening tag, seems to work)

4. Close Visual Studio if it's running, re-open, ta-da you now have Intellisense as well as no more annoying "Could not find schema information for..." messages.
