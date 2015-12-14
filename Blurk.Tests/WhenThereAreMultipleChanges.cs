using NUnit.Framework;
using Shouldly;

namespace Blurk.Tests
{
    [TestFixture]
    public class WhenThereAreMultipleChanges
    {
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


        [Test]
        public void TheyShouldAppearInOrder()
        {
            var diffs = Blurk.Compare(Expected).To(Actual).Differences();

            diffs.Length.ShouldBe(3);
            diffs[0].ShouldStartWith("+Two point five");
            diffs[1].ShouldStartWith("-Four");
            diffs[2].ShouldStartWith("+Five and three quarters");
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