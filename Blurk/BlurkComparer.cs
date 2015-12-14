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

        private static IEnumerable<LineCompareResult> CompareStrings(string expected, string actual)
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
                    yield return 
                        new LineCompareResult(LineType.Addition, line, lineNumberActual, LineSource.Actual);
                }
                else if (match.index == consumedExpected)
                {
                    consumedExpected++;
                    yield return new LineCompareResult(LineType.Matched, line, lineNumberActual, LineSource.Actual);
                }
                else
                {
                    foreach (var deletedLine in expectedLines
                        .Skip(consumedExpected)
                        .TakeWhile(l => l.index < match.index))
                    {
                        yield return
                            new LineCompareResult(LineType.Deleted, deletedLine.line, deletedLine.index + 1,
                                LineSource.Expected);
                    }
                    consumedExpected = match.index + 1;
                    yield return new LineCompareResult(LineType.Matched, line, lineNumberActual, LineSource.Actual);
                }
                lineNumberActual++;
            }
            foreach (var deletedLine in expectedLines
                        .Skip(consumedExpected))
            {
                yield return
                    new LineCompareResult(LineType.Deleted, deletedLine.line, deletedLine.index + 1, LineSource.Expected);
            }

        }

    }
}
