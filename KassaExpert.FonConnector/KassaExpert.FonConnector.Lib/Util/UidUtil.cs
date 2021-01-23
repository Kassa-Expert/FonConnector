using System.Text.RegularExpressions;

namespace KassaExpert.FonConnector.Lib.Util
{
    internal static class UidUtil
    {
        internal static bool IsValidUid(this string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                return false;
            }

            return Regex.IsMatch(uid, @"^ATU[a-zA-Z0-9]{8}$");
        }
    }
}