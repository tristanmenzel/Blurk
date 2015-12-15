# Blurk
A simple line based string comparison tool for unit testing

## Installation

**Nuget**
```ps
Install-Package Blurk
```

## Usage

**With failure assertion**

```cs
Blurk.Compare(Expected).To(Actual).AssertAreTheSame(Assert.Fail)
```

**Just get the differences and do your own thing**

```cs
var diffs = Blurk.Compare(Expected).To(Actual).Differences();
```

**View all compared lines including matched**

```cs
var allLines = Blurk.Compare(Expected).To(Actual).All();
```

**Raw results as LineCompareResult[] to do with as you please...**
```cs
var raw = Blurk.Compare(Expected).To(Actual).RawResults();
```
