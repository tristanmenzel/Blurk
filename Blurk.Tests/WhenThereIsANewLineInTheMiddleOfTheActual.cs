using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace BlurkCompare.Tests
{
    [TestFixture]
    public class WhenThereIsANewLineInTheMiddleOfTheActual
    {
        private const string Expected = @"Once
upon
a
time
there
was
a
dog";
        private const string Actual = @"Once
upon
a
time
there
was
a
fat
dog";


        [Test]
        public void ItShouldShowAsAnAddition()
        {
         
            var diffs = Blurk.Compare(Expected).To(Actual).Differences();
            diffs.Length.ShouldBe(1);
            diffs.First().First().ShouldBe('+');
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