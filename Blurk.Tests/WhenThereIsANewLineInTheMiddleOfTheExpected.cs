using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenThereIsANewLineInTheMiddleOfTheExpected
    {
        private const string Expected = @"Three
Blind
mice";
        private const string Actual = @"Three
mice";

        [Test]
        public void ItShouldShowAsADeletion()
        {
            var diffs = Blurk.Compare(Expected).To(Actual).Differences();
            diffs.Length.ShouldBe(1);
            diffs.First().First().ShouldBe('-');
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