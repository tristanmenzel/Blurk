using System;
using System.Collections.Generic;
using System.Linq;

namespace BlurkCompare
{
    public class ComparisonResult
    {
        private readonly LineCompareResult[] _lineCompareResults;

        public ComparisonResult(IEnumerable<LineCompareResult> lineCompareResults)
        {
            _lineCompareResults = lineCompareResults.ToArray();
        }

        public string[] Differences()
        {
            return _lineCompareResults.Where(r => r.LineType != LineType.Matched).Select(r => (string) r).ToArray();
        }

        public string[] All()
        {
            return _lineCompareResults.Select(r => (string) r).ToArray();
        }

        public LineCompareResult[] RawResults()
        {
            return _lineCompareResults;
        }


        public void AssertAreTheSame(Action<string> assertionFailDelegate)
        {
            if (_lineCompareResults.Any(r => r.LineType != LineType.Matched))
            {
                assertionFailDelegate(string.Format("Expected does not match actual: \r\n\r\n{0}",
                    string.Join("\r\n", Differences())));
            }
        }
    }
}