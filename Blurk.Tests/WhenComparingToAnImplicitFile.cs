using NUnit.Framework;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenComparingToAnImplicitFile
    {
        [Test]
        public void ExpectTheFileToBeLoadedBasedOnClassAndMethodName()
        {
            Blurk.CompareImplicitFile()
                .To("Why hello there")
                .AssertAreTheSame(Assert.Fail);
        }
    }
}