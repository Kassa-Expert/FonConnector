using System.Text.RegularExpressions;

namespace KassaExpert.FonConnector.Lib.Util
{
    internal static class UidUtil
    {
        /// <summary>
        /// http://www.pruefziffernberechnung.de/U/USt-IdNr.shtml#PZAT
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        internal static bool IsValidUid(this string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                return false;
            }

            if (!Regex.IsMatch(uid, @"^ATU[a-zA-Z0-9]{8}$"))
            {
                return false;
            }

            if (!int.TryParse(uid[10].ToString(), out int lastDigit))
            {
                return false;
            }

            return lastDigit == CalcCheckSum(uid.Substring(3));
        }

        private static int CalcCheckSum(string numberPart)
        {
            int sum = 0;

            for (int i = 0; i < 7; i++)
            {
                var gewicht = (i % 2) + 1;

                sum += gewicht * int.Parse(numberPart[i].ToString());
            }

            return (96 - sum) % 10;
        }
    }
}