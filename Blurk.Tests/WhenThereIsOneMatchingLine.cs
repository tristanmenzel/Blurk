using NUnit.Framework;
using Shouldly;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenThereIsOneMatchingLine
    {

        const string Expected = "This";
        const string Actual = "This";

        [Test]
        public void ItShouldReturnNoDifferences()
        {

            var diffs = Blurk.Compare(Expected)
                .To(Actual)
                .Differences();

            diffs.Length.ShouldBe(0);
        }


        [Test]
        public void AnAssertionThatTheyAreTheSameShouldPass()
        {
            Blurk.Compare(Expected).To(Actual).AssertAreTheSame(Assert.Fail);
        }
    }
}