using System.Collections.Generic;
using System.Text;

namespace DayFourteen
{
    public static class Extensions
    {
        public static string ToBinaryString(this IEnumerable<char> charArray)
        {
            var builder = new StringBuilder();
            
            foreach (var t in charArray)
            {
                builder.Append(t);
            }

            return builder.ToString();
        }
    }
}