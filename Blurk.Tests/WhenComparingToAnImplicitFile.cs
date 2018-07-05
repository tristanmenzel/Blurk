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
        
        [Test]
        public void ExpectTheFileToBeLoadedBasedOnClassAndMethodNameAndSpecifiedExtension()
        {
            Blurk.CompareImplicitFile("js")
                .To("alert('Why hello there');")
                .AssertAreTheSame(Assert.Fail);
        }
    }
}