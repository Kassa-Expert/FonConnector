using System;
using System.Collections.Generic;
using System.Text;

namespace KassaExpert.FonConnector.Lib.Util
{
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

            return true;
        }
    }
}