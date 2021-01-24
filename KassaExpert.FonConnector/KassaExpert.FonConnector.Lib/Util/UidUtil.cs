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

            var lastDigit = int.Parse(uid[10].ToString());

            return lastDigit == CalcCheckSum(uid.Substring(3));
        }

        /// <summary>
        /// https://www.bmf.gv.at/dam/jcr:9f9f8d5f-5496-4886-aa4f-81a4e39ba83e/BMF_UID_Konstruktionsregeln.pdf
        /// </summary>
        public static int CalcCheckSum(string numberPart)
        {
            var s3 = calcS(3);
            var s5 = calcS(5);
            var s7 = calcS(7);

            var r = s3 + s5 + s7;

            return (10 - ((r + c(2) + c(4) + c(6) + c(8) + 4) % 10)) % 10;

            int c(int position)
            {
                var index = position - 2;
                return int.Parse(numberPart[index].ToString());
            }

            int calcS(int position)
            {
                var ci = c(position);

                return ((ci / 5) + (ci * 2) % 10);
            }
        }
    }
}