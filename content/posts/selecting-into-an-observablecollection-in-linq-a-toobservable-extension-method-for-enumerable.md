+++
title = "Selecting into an ObservableCollection in LINQ: a ToObservable() extension method for Enumerable"
date = "2012-02-09T21:04:55Z"
categories = ["Code"]
tags = ["Microsoft", "C#"]
draft = false
+++

I love me to some LINQ, especially some LINQ to XML (otherwise known as XLinq) for parsing meaty XML files into objects. Anywhere there is XML parsing going on in my app you'll see code similar to this:

```csharp
var list = (from review in reviews.Descendants("review")
           select new BookReview
           {
                StartedAt = (string)review.Element("started_at"),
                Book = (from b in review.Elements("book")
                select new Book((string)b.Element("id"))
                {
                    Title = (string)b.Element("title"),
                    CoverUrl = new Uri((string)b.Element("image_url")),
                    NumberOfPages = (string)b.Element("num_pages"),
                    AverageRating = (string)b.Element("average_rating"),
                    Description = (string)b.Element("description").Value,
                    Authors = (from a in b.Descendants("author")
                                select new Author
                                      {
                                          Name = (string)a.Element("name")
                                      }).ToObservable<Author>()
                      }).SingleOrDefault()
          }).ToList();
```

This is a medium complexity example, I'm selecting a list of `BookReview` objects which contains a `Book` which in turn has a collection of `Author` objects.

One thing to pay attention to is that the default return type for a collection of items returned via LINQ is a `Enumerable` and if you're using a different collection type you'll need to use one of the built-in extension methods to convert it to the appropriate collection type. You can see where I'm doing this on the last line above with the call to `ToList()`.

There are built-in extension methods to convert to List, Dictionary, Array and a bevy of others but not `ObservableCollection`, which you're probably using in some form if you're data binding your collection to your UI. You could select into an Enumerable and then manually add each item into your ObservableCollection but that's no fun and it's much simpler to just write your own Enumerable extension method to take care of it:

```csharp
public static class Enumerable
{
    public static ObservableCollection<TSource> ToObservable<TSource>(this IEnumerable<TSource> source)
    {
        return new ObservableCollection<TSource>(source);
    }
}
```

I'm using it in the first sample to convert the Authors collection. Hope you find this useful, I know I use it all the time in my Windows Phone apps!

By the way it's also a "gist", a version controlled snippet, over on github.com: [LinqExtensions.cs](https://gist.github.com/fcf07029eec152ec80f7).
