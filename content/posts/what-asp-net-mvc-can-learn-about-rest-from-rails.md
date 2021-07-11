+++
title = "What ASP.NET MVC Can Learn About REST from Rails"
date = "2008-02-20T08:47:00Z"
categories = ["Code"]
tags = ["ASP.NET", "MVC", "Ruby", "Rails"]
draft = false
+++

I'm starting to see more ASP.NET MVC samples and questions come out and I'm realizing that a large portion of the ASP.NET crowd doesn't even realize that a huge reason for the MVC movement is because of the Ruby on Rails framework. A lot of new .NET MVC developers are struggling with architectural questions that have already been debated and answered in the Rails community, which makes Rails a great resource for when you're first starting out or you're curious how to handle certain situations, like nested resources or how to structure your controllers.

Speaking of controllers one great thing from Rails that I hope more MVC developers embrace is REST. Instead of repeating everything just watch David Heinemeier Hansson's keynote speech from RailsConf back in 2006. Sure, it's almost two years but for ASP.NET developers it may as well be yesterday. I'd suggest starting from the second part since the first segment is just normal conference ra-ra-ra.

[Check it out here](http://www.scribemedia.org/2006/07/09/dhh) (don't forget to download the slides that he refers to [here](http://downloads.scribemedia.net/rails2006/worldofresources.pdf)).

## Note

He talks about using a semi-colon in the URL to denote an aspect/action of a controller, like this:

```ruby
/people/1;edit
```

Well, you can ignore that and just assume he *really* meant to say:

```ruby
/people/1/edit
```

They dropped that semi-colon silliness in Rails 2.0 and it feels much cleaner.