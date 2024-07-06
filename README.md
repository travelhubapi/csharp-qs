#QueryString

A query string utility for .NET to stringify complex objects

### Usage

```cs
using QueryString;

var post = new Post();
post.title = "Post Title";
post.comments = new Comment[] {
  {id: 1, message: "fool", author: new Author() { name: "Author Name"} }
};
var queryString = QS.Stringify(post);

System.Console.WriteLine(System.Web.HttpUtility.UrlDecode(queryString));
// title=Post title&comments[0][id]=1&comments[0][message]=fool&comments[0][author][name]=Author Name

```

#### With prefix

```cs
using QueryString;

var comments = new Comment[] {
  {id: 1, message: "fool", author: new Author() { name: "Author Name"} }
};

var queryString = QS.Stringify(comments, encode = false);
System.Console.WriteLine(queryString);
// 0[id]=1&0[message]=fool&0[author][name]=Author Name

queryString = QS.Stringify(comments, prefix = "comments", encode = false);
System.Console.WriteLine(queryString);
// comments[0][id]=1&comments[0][message]=fool&comments[0][author][name]=Author Name


```

#### Flurl (https://flurl.dev/)

You can add the following extensionMethod on Flurl and use it fluent instead of `SetQueryParams()` (https://flurl.dev/docs/fluent-url/#fluent-url-building).

```cs
public static Url SetQueryParamsFromComplexObject(this Url @this, object obj, NullValueHandling nullValueHandling = NullValueHandling.Remove)
{
    if (obj == null)
        return @this;
    foreach (var kv in QS.ToKeyValuePairs(obj))
        @this.SetQueryParam(kv.Key, kv.Value, nullValueHandling);
    return @this;
}
```

### Parameter

`QS.Stringify(object obj, prefix = "")`

* obj - Object to be stringified
* prefix - a prefix to parameters in output
