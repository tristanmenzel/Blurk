# Blurk

A simple line based string comparison tool for unit testing

[![Build status](https://ci.appveyor.com/api/projects/status/51qn88aqwojtp97u?svg=true)](https://ci.appveyor.com/project/tristanmenzel/blurk)

## Installation

**Nuget**
```ps
Install-Package Blurk
```

## Usage

### In memory

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

### Compare to file

**Compare to a specific file**

```cs
Blurk.CompareFile("../../../WhenComparingToAFile.txt")
    .To("Happy days")
    .AssertAreTheSame(Assert.Fail);
```

**Compare to an implicitly located file**
```cs
[Test]
public void ExpectTheFileToBeLoadedBasedOnClassAndMethodName()
{
    Blurk.CompareImplicitFile("txt") // File extension, txt is default
        .To("Why hello there")
        .AssertAreTheSame(Assert.Fail);
}
```

The file will be created if it does not exist


## Sample output

**This test...**
```cs
private const string Actual = @"One
Two
Two point five
Three
Five
Five and three quarters
Six
Seven";
    
private const string Expected = @"One
Two
Three
Four
Five
Six
Seven";

Blurk.Compare(Expected).To(Actual).AssertAreTheSame(Assert.Fail);
```
**...will produce this output**
```
Expected does not match actual: 

+Two point five (Source: Actual line 3)
-Four (Source: Expected line 4)
+Five and three quarters (Source: Actual line 6)
```
