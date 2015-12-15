using NUnit.Framework;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenTheLineEndingsAreDifferent
    {
        [Test]
        public void ItShouldNotChangeTheOutcome()
        {
            var expected = "This\r\nshould\r\nbe\r\nthe\r\nsame.";
            var actual = "This\nshould\nbe\nthe\nsame.";

            Blurk.Compare(expected).To(actual).AssertAreTheSame(Assert.Fail);
        }
    }
}