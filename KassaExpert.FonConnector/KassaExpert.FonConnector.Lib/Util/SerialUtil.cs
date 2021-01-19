using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace KassaExpert.FonConnector.Lib.Util
{
    /// <summary>
    /// Serial is the Serial-Number from the signing certificate
    /// </summary>
    internal static class SerialUtil
    {
        internal static bool IsValidHexSerial(this string hexSerial)
        {
            var trimmed = hexSerial.Trim();

            if (string.IsNullOrEmpty(trimmed))
            {
                return false;
            }

            //der Präfix 0x wird nicht angegeben
            if (trimmed.StartsWith("0x"))
            {
                return false;
            }

            return Regex.IsMatch(trimmed, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}