using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Blurk.Tests
{
    [TestFixture]
    public class WhenThereIsOneLineInTheExpectedAndNoLinesInTheActual
    {
        [Test]
        public void ItShouldReturnASingleDeletion()
        {
            var expected = "This";
            var actual = "";

            var diffs = Blurk.Compare(expected)
                .To(actual)
                .Differences();

            diffs.Length.ShouldBe(1);
            diffs.First().First().ShouldBe('-');
        }

    }
}
