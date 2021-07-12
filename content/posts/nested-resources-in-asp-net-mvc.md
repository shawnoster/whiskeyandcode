+++
title = "Nested Resources In ASP.NET MVC"
date = "2008-02-08T19:08:00Z"
categories = ["Code"]
tags = ["ASP.NET", "MVC"]
draft = false
+++

Often you'll need to represent some hierarchical or parent-child relationship in your application and one thing you'll struggle with is how to cleanly mesh both the parent and child controllers yet keep them nice and RESTful. The secret is in good routing.

## The problem

A popular example is tickets belonging to events (event as in Burning Man, not OnClick) and you want to get all the tickets for a certain event, as well as be able to work with just tickets or events. You want nice and pretty urls as well, so you're hoping for something like this:

| route | description |
| ----- | ----------- |
| /events/1/tickets | all tickets for event 1 |
| /events/1/tickets/new | add a new ticket for event 1 |
| /tickets/list | all tickets for all events |

## The Messy Way

My first idea was to add a Tickets action to my Events controller so I could call `EventsController.Tickets(int eventId)` but that didn't really help when I wanted to view all the tickets for all the events. Plus it broke the whole REST idea and that's bad for maintainability.

My second idea was a butt-ugly url along the lines of `/tickets/list?event_id=1` but that just kicks the whole MVC, SEO-friendly url philosophy in the nuts. Repeatedly.

## The Routes Way

A **Big Thanks** goes to Adam Wiggins whose [post about nested resources](http://adam.blog.heroku.com/past/2007/12/20/nested_resources_in_rails_2/) finally set off the lightbulb in my brain. Instead of trying to make my controllers do all the work why not take advantage of the actual mechanism that's there to handle these sorts of things and put it to use. That would be the routing mechanism that makes all your urls pretty and dictates which controller does what. Here is the way to keep your urls pretty and to have both a separate Events and Tickets controller yet still maintain the cool parent/child relationship:

```csharp
RouteTable.Routes.Add(
    new Route {
        Url = "events/[eventId]/tickets/[action]/[id]",
        Defaults = new {
            controller = "Tickets",
            action = "List",
            id = (string)null 
  },
  RouteHandler = typeof(MvcRouteHandler) });
```

Once I discovered this I smacked myself on the forehead for not realizing just how simple this whole thing was.