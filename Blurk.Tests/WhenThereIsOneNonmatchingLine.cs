using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenThereIsOneNonmatchingLine
    {
        const string Expected = "This";
        const string Actual = "That";

        [Test]
        public void ItShouldReturnAnAdditionAndADeletion()
        {

            var diffs = Blurk.Compare(Expected)
                .To(Actual)
                .Differences();

            diffs.Length.ShouldBe(2);
            diffs.Count(x => x.First() == '+').ShouldBe(1);
            diffs.Count(x => x.First() == '-').ShouldBe(1);

        }
        [Test]
        public void AnAssertionThatTheyAreTheSameShouldFail()
        {
            bool didFail = false;
            Blurk.Compare(Expected).To(Actual).AssertAreTheSame(x => didFail = true);
            didFail.ShouldBeTrue();
        }
    }
}