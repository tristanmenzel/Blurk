﻿using System.ComponentModel;
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

        public static HalfComparison CompareImplicitFile([CallerFilePath] string filePath = null,
            [CallerMemberName] string memberName = null)
        {
            var fileName = new Regex("\\.[a-zA-Z0-9]{1,3}$").Replace(filePath, $".{memberName}.txt");
            return CompareFile(fileName);
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