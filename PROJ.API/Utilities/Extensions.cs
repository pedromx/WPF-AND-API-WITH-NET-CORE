using System.Linq;

namespace PROJECT.API.Utilities
{
    public static class Extensions
    {
        public static int QuantityOf(this string text, char chr)
        {
            var quantity = text.Count(x => x.Equals(chr));
            return quantity;
        }
    }
}
