namespace HWRegEx
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Format($"\tA regular expression, regex or regexp[1](sometimes called " +
                $"a rational expression)[2][3] is, in theoretical computer science and formal " +
                $"language theory, a sequence of characters that define a search pattern.Usually " +
                $"this pattern is then used by string searching algorithms for \"find\" or \"find " +
                $"and replace\" operations on strings. " + Environment.NewLine +
                $"\tThe concept arose in the 1950s when the " +
                $"American mathematician Stephen Cole Kleene formalized " +
                $"the description of a regular language.The concept came into common use " +
                $"with Unix text - processing utilities.Since the 1980s, different syntaxes " +
                $"for writing regular expressions exist, one being the POSIX standard and " +
                $"another, widely used, being the Perl syntax." + Environment.NewLine +
                $"\tRegular expressions are used in search engines, search and replace " +
                $"dialogs of word processors and text editors, in text processing utilities " +
                $"such as sed and AWK and in lexical analysis.Many programming languages " +
                $"provide regex capabilities, built -in or via libraries.");

            // The text itself without citation remarks (e.g., [1],[2]);
            var patternWithoutCitationRemarks = @"\[\d+\]";
            var withoutCitationRemarks = Regex.Replace(input, patternWithoutCitationRemarks, string.Empty);

            // Years mentioned in the text;
            var patternForYears = new Regex(@"\d{4}s");
            var years = patternForYears.Matches(input);

            // How many times the word “regular” is used (regardless case);
            var patternForRegular = new Regex(@"(?i)regular");
            var countOfWordRegular = patternForRegular.Matches(input).Count;

            // All places where regular expressions are used
            var patternForLastParagraph = new Regex(@"\t.+$");
            var lastParagraph = patternForLastParagraph.Match(input).Value;
            var countWordRegular = new Regex(@"(?ix)regular\ expressions | regex ");
            var placesWithRegEx = countWordRegular.Matches(lastParagraph);
        }
    }
}
