using System;
using System.Text;

namespace KassaExpert.FonConnector.Lib
{
    internal static class RandomUtil
    {
        internal static string GetRandomNumberString(int length = 9)
        {
            Random random = new Random();

            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(0, 9));
            }

            return sb.ToString();
        }
    }
}