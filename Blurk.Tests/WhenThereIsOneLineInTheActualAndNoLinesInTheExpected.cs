using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Blurk.Tests
{
    [TestFixture]
    public class WhenThereIsOneLineInTheActualAndNoLinesInTheExpected
    {

        [Test]
        public void ItShouldReturnASingleAddition()
        {
            var expected = "";
            var actual = "That";

            var diffs = Blurk.Compare(expected)
                .To(actual)
                .Differences();

            diffs.Length.ShouldBe(1);
            diffs.First().First().ShouldBe('+');
        }
    }
}