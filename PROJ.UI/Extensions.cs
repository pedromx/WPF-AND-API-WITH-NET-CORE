namespace PROJECT.UI
{
    public static class Extensions
    {
        public static string RemoveCarriageReturn(this string text)
        {
            return text.Trim().Replace("\r", " ").Replace("\n", " ");
        }
    }
}
