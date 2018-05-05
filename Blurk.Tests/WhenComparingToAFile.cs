using System;
using NUnit.Framework;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenComparingToAFile
    {
        [Test]
        public void TheContentsOfTheFileIsLoadedAndCompared()
        {
            Blurk.CompareFile("../../../WhenComparingToAFile.txt")
                .To("Happy days")
                .AssertAreTheSame(Assert.Fail);
        }
        
    }
}