using System.Text.RegularExpressions;

namespace StringsAndLanguagesApp.StringsCore
{
    static class StringUtils
    {
        public const string VALID_INPUT_PATTERN = "^([a-z]|[0-9])$";

        public static bool isValid(char input)
        {
            return Regex.IsMatch(input.ToString(), VALID_INPUT_PATTERN);
        }
    }
}
