namespace Integra.Web.Helpers
{
    public static class StringHelper
    {
        public static string UpperCaseFirstChar(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}