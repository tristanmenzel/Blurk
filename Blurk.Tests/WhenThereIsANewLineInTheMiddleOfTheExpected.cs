using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Blurk.Tests
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
            Should.Throw<AssertionException>(() => {
                Blurk.Compare(Expected).To(Actual).AssertAreTheSame(Assert.Fail);
            });
        }
    }
}