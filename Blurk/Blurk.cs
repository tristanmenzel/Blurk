using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace BlurkCompare
{
    public static class Blurk
    {
        public static class Settings
        {
            public static bool WriteActualToFile { get; set; }
        }
        
        public static HalfComparison Compare(string expected)
        {
            return new HalfComparison(expected, "txt");
        }

        public static HalfComparison CompareFile(string filePath)
        {
            using (var sr = new StreamReader(File.OpenRead(filePath)))
            {
                var expected = sr.ReadToEnd();
                return new HalfComparison(expected, Path.GetExtension(filePath));
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
            private readonly string _extension;

            public HalfComparison(string expected, string extension)
            {
                _expected = expected;
                _extension = extension;
            }

            public ComparisonResult To(string actual,
                bool? writeActualToFile = null,
                string extension = null,
                [CallerFilePath] string filePath = null,
                [CallerMemberName] string memberName = null
            )
            {
                if (writeActualToFile ?? Settings.WriteActualToFile)
                {
                    var fileName = GetFileName($"actual.{extension ?? _extension}", filePath, memberName);
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