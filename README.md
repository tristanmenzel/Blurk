# Blurk
A simple line based string comparison tool for unit testing

# Usage

**With failure assertion**

```cs
Blurk.Compare(Expected).To(Actual).AssertAreTheSame(Assert.Fail)
```

**Just get the differences and do your own thing**

```cs
var diffs = Blurk.Compare(Expected).To(Actual).Differences();
```
