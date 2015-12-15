using System;

namespace Blurk
{
    public struct LineCompareResult
    {
        public LineCompareResult(LineType lineType, string lineText, int lineNumber, LineSource source)
        {
            LineType = lineType;
            LineText = lineText;
            LineNumber = lineNumber;
            Source = source;
        }

        public LineType LineType { get; private set; }
        public string LineText { get; private set; }
        public int LineNumber { get; private set; }
        public LineSource Source { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}{1} (Source: {2} line {3})",
                LineType.GetSymbol(),
                LineText,
                Source,
                LineNumber);
        }

        public static implicit operator string(LineCompareResult result)
        {
            return result.ToString();
        }
    }

    public enum LineType
    {
        Addition,
        Matched,
        Deleted
    }

    public enum LineSource
    {
        Expected,
        Actual
    }
}