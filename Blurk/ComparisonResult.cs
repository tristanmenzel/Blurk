using System;
using System.Collections.Generic;
using System.Linq;

namespace Blurk
{
    public class ComparisonResult
    {
        private readonly string[] _differences;

        public ComparisonResult(IEnumerable<string> differences)
        {
            _differences = differences.ToArray();
        }

        public string[] Differences()
        {
            return _differences;
        }


        public void AssertAreTheSame(Action<string> assertionFailDelegate)
        {
            if (_differences.Any())
            {
                assertionFailDelegate(string.Format("Expected does not match actual: \r\n\r\n{0}",
                    string.Join("\r\n", _differences)));
            }
        }
    }
}