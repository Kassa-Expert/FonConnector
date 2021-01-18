using System;

namespace KassaExpert.FonConnector.Lib.Util
{
    internal static class DateUtil
    {
        internal static DateTime GetAustriaDateNow()
        {
            return DateTime.Now; //TODO USE UTC AND CONVERT TO AUSTRIA TO BE ALWAYS CORRECT
        }
    }
}