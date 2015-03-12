using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string values)
        {
            return
                values.SplitExcludingDelimiter()
                    .FilterNegativeNumbers()
                    .FilterNumbersGreaterThan1000()
                    .Sum(x => x.SafelyParseToInt());
        }
    }

    public static class Extensions
    {
        public static string StripNewLineCharacters(this string originalString)
        {
            return originalString.Replace("\n", GetDelimiter(originalString));
        }

        public static string[] SplitExcludingDelimiter(this string originalString)
        {
            return originalString.StartsWith("//")
                ? originalString.Substring(originalString.IndexOf("\n", StringComparison.InvariantCultureIgnoreCase) + 1)
                    .Split(GetDelimiter(originalString).ToCharArray())
                : originalString.StripNewLineCharacters().Split(",".ToCharArray());
        }

        public static string[] FilterNegativeNumbers(this string[] splitValues)
        {
            return splitValues.ToList().Any(x => x.SafelyParseToInt() < 0)
                ? splitValues.Where(x => x.SafelyParseToInt() < 0).ToArray().Throw("negatives not allowed")
                : splitValues;
        }

        public static string[] FilterNumbersGreaterThan1000(this string[] splitValues)
        {
            return splitValues.Where(x => x.SafelyParseToInt() <= 1000).ToArray();
        }

        private static string GetDelimiter(string values)
        {
            return values.StartsWith("//")
                ? values.Substring(2, values.IndexOf("\r", StringComparison.InvariantCultureIgnoreCase) - 2)
                : ",";
        }

        public static int SafelyParseToInt(this string values)
        {
            int parsedValue = 0;
            return Int32.TryParse(values, out parsedValue) ? parsedValue : 0;
        }

        public static string[] Throw(this string[] values, string message)
        {
            throw new Exception(string.Format("{0} {1}", message, values.Aggregate((s, s1) => s + " " + s1)));
        }
    }
}
