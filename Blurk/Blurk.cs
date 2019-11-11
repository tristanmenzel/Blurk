using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace BlurkCompare
{
    public static class Blurk
    {
        public static HalfComparison Compare(string expected)
        {
            return new HalfComparison(expected);
        }

        public static HalfComparison CompareFile(string filePath)
        {
            using (var sr = new StreamReader(File.OpenRead(filePath)))
            {
                var expected = sr.ReadToEnd();
                return new HalfComparison(expected);
            }
        }


        public static HalfComparison CompareImplicitFile(string extension = "txt",
            [CallerFilePath] string filePath = null,
            [CallerMemberName] string memberName = null)
        {
            var fileName = GetFileName(extension, filePath, memberName);
            if (!File.Exists(fileName))
            {
                using (var f = File.Create(fileName))
                {
                }
            }

            return CompareFile(fileName);
        }

        private static string GetFileName(string extension, string filePath, string memberName)
        {
            var fileName = new Regex("\\.[a-zA-Z0-9]{1,3}$").Replace(filePath, $".{memberName}.{extension}");
            return fileName;
        }

        public class HalfComparison
        {
            private readonly string _expected;

            public HalfComparison(string expected)
            {
                _expected = expected;
            }

            public ComparisonResult To(string actual,
                bool writeActualToFile = false,
                string extension = "txt",
                [CallerFilePath] string filePath = null,
                [CallerMemberName] string memberName = null
            )
            {
                if (writeActualToFile)
                {
                    var fileName = GetFileName($"actual.{extension}", filePath, memberName);
                    using (var f = File.Open(fileName, FileMode.Create))
                    using (var sw = new StreamWriter(f))
                    {
                        sw.Write(actual);
                    }
                }

                return BlurkComparer.Compare(_expected, actual);
            }
        }
    }
}