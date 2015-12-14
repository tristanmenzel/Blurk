using System;
using System.Collections.Generic;
using System.Linq;

namespace Blurk
{
    public static class BlurkComparer
    {
        public static ComparisonResult Compare(string expected, string actual)
        {
            return new ComparisonResult(CompareStrings(expected, actual));
        }

        private static IEnumerable<string> CompareStrings(string expected, string actual)
        {

            var actualLines = actual.Replace("\r", "").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var expectedLines = expected.Replace("\r", "").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select((line, index) => new { line, index })
                .ToArray();

            int consumedExpected = 0;

            int lineNumberActual = 1;

            foreach (var line in actualLines)
            {
                var match = expectedLines.Skip(consumedExpected).FirstOrDefault(l => l.line == line);
                if (match == null)
                {
                    yield return Addition(line, lineNumberActual, "actual");
                }
                else if (match.index == consumedExpected)
                {
                    consumedExpected++;
                }
                else
                {
                    foreach (var deletedLine in expectedLines
                        .Skip(consumedExpected)
                        .TakeWhile(l => l.index < match.index))
                    {
                        yield return Deletion(deletedLine.line, deletedLine.index + 1, "expected");
                    }
                    consumedExpected = match.index + 1;
                }
                lineNumberActual++;
            }
            foreach (var deletedLine in expectedLines
                        .Skip(consumedExpected))
            {
                yield return Deletion(deletedLine.line, deletedLine.index + 1, "expected");
            }

        }

        private static string Addition(string line, int lineNumber, string fileName)
        {
            return string.Format("+{0} (Source: {2} line {1})", line, lineNumber, fileName);
        }


        private static string Deletion(string line, int lineNumber, string fileName)
        {
            return string.Format("-{0} (Source: {2} line {1})", line, lineNumber, fileName);
        }
    }
}
