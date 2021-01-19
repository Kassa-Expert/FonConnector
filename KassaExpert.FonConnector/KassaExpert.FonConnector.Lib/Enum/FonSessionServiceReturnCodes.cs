using Enum.Ext;
using System.Linq;

namespace KassaExpert.FonConnector.Lib.Enum
{
    /// <summary>
    /// to check the response code given here: https://www.bmf.gv.at/dam/jcr:19c193f4-99cd-42ff-9b23-655f2ab5734e/BMF_Registrierkassen_Webservice.pdf
    /// </summary>
    public sealed class FonSessionServiceReturnCodes : TypeSafeEnum<FonSessionServiceReturnCodes, int>
    {
        public static readonly FonSessionServiceReturnCodes RC_00 = new FonSessionServiceReturnCodes(0, true, "Aufruf ok");
        public static readonly FonSessionServiceReturnCodes RC_01 = new FonSessionServiceReturnCodes(-1, true, "Die Session ID ist ungültig oder abgelaufen.");
        public static readonly FonSessionServiceReturnCodes RC_02 = new FonSessionServiceReturnCodes(-2, true, "Der Aufruf des Webservices ist derzeit wegen Wartungsarbeiten nicht möglich.");
        public static readonly FonSessionServiceReturnCodes RC_03 = new FonSessionServiceReturnCodes(-3, true, "Es ist ein technischer Fehler aufgetreten.");
        public static readonly FonSessionServiceReturnCodes RC_04 = new FonSessionServiceReturnCodes(-4, true, "Die übermittelten Zugangsdaten sind ungültig");
        public static readonly FonSessionServiceReturnCodes RC_05 = new FonSessionServiceReturnCodes(-5, true, "Benutzer nach mehreren Fehlversuchen gesperrt.");
        public static readonly FonSessionServiceReturnCodes RC_06 = new FonSessionServiceReturnCodes(-6, true, "Der Benutzer ist gesperrt.");
        public static readonly FonSessionServiceReturnCodes RC_07 = new FonSessionServiceReturnCodes(-7, true, "Der Benutzer ist kein Webservice-User.");

        private FonSessionServiceReturnCodes(int returnCode, bool success, string errorMessage) : base(returnCode)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }

        public static FonSessionServiceReturnCodes GetByFonReturnCode(int fonReturnCode) => (FonSessionServiceReturnCodes)GetById(fonReturnCode);
    }
}