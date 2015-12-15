using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenThereIsASingleChangedLine
    {
        private const string Expected = @"Here
is
a changed line
for you";
        private const string Actual = @"Here
is
a Changed line
for you";

        [Test]
        public void ItShouldShowUpAsAnAdditionAndADeletion()
        {
            

            var diffs = Blurk.Compare(Expected).To(Actual).Differences();

            diffs.Length.ShouldBe(2);

            diffs.Count(x => x.First() == '+').ShouldBe(1);
            diffs.Count(x => x.First() == '-').ShouldBe(1);
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