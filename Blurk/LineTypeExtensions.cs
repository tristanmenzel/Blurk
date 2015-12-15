namespace BlurkCompare
{
    public static class LineTypeExtensions
    {
        public static string GetSymbol(this LineType type)
        {
            switch (type)
            {
                case LineType.Addition:
                    return "+";
                case LineType.Deleted:
                    return "-";
                default:
                    return "";
            }
        }

    }
}