namespace Blurk
{
    public static class Blurk
    {
        public static HalfComparison Compare(string expected)
        {
            return new HalfComparison(expected);
        }

        public class HalfComparison
        {
            private readonly string _expected;

            public HalfComparison(string expected)
            {
                _expected = expected;
            }

            public ComparisonResult To(string actual)
            {
                return BlurkComparer.Compare(_expected, actual);
            }

        }

      
    }
}