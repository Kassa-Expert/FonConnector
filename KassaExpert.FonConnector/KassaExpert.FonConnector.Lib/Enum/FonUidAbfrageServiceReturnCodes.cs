using Enum.Ext;

namespace KassaExpert.FonConnector.Lib.Enum
{
    /// <summary>
    /// to check the response code given here: https://www.bmf.gv.at/dam/jcr:19c193f4-99cd-42ff-9b23-655f2ab5734e/BMF_Registrierkassen_Webservice.pdf
    /// </summary>
    public sealed class FonUidAbfrageServiceReturnCodes : TypeSafeEnum<FonUidAbfrageServiceReturnCodes, int>
    {
        public static readonly FonUidAbfrageServiceReturnCodes RC_00 = new FonUidAbfrageServiceReturnCodes(0, true, "Die UID des Erwerbers ist gültig");
        public static readonly FonUidAbfrageServiceReturnCodes RC_01 = new FonUidAbfrageServiceReturnCodes(-1, false, "Die Session ID ist ungültig oder abgelaufen.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_02 = new FonUidAbfrageServiceReturnCodes(-2, false, "Der Aufruf des Webservices ist derzeit wegen Wartungsarbeiten nicht möglich.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_03 = new FonUidAbfrageServiceReturnCodes(-3, false, "Es ist ein technischer Fehler aufgetreten.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_04 = new FonUidAbfrageServiceReturnCodes(-4, false, "Dieser Teilnehmer ist für diese Funktion nicht berechtigt.");

        public static readonly FonUidAbfrageServiceReturnCodes RC_05 = new FonUidAbfrageServiceReturnCodes(1, false, "Die UID des Erwerbers ist nicht gültig.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_06 = new FonUidAbfrageServiceReturnCodes(4, false, "Die UID-Nummer des Erwerbers ist falsch.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_07 = new FonUidAbfrageServiceReturnCodes(5, false, "Die UID-Nummer des Antragstellers ist ungültig.");

        public static readonly FonUidAbfrageServiceReturnCodes RC_08 = new FonUidAbfrageServiceReturnCodes(10, false, "Der angegebene Mitgliedstaat verbietet diese Abfrage.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_09 = new FonUidAbfrageServiceReturnCodes(101, false, "UID beginnt nicht mit ATU.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_10 = new FonUidAbfrageServiceReturnCodes(103, false, "Die angefragte UID-Nummer kann im FinanzOnline nur in Stufe 1 bestätigt werden, da diese UID-Nummer zu einer Unternehmensgruppe (Umsatzsteuergruppe) gehört. Aus technischen Gründen werden aus Tschechien keine Firmendaten angezeigt. Für eine gültige Stufe 2 Abfrage ist es daher erforderlich, dass Sie unter http://adisreg.mfcr.cz die Daten der CZ-Umsatzsteuergruppe aufrufen und kontrollieren, ob das angefragte Unternehmen auch tatsächlich zu dieser Gruppe gehört. Bitte bewahren Sie den Ausdruck dieser Anfrage in Ihren Unterlagen als Beleg gemäß § 132 BAO auf. Für jede Anfrage Stufe 2 ist sowohl das Bestätigungsverfahren in Stufe 1 im FinanzOnline als auch das Gruppenregister im anderen Mitgliedsstaat laut o.a. Link zu konsultieren. Im Falle von Fragen wenden Sie sich bitte an Ihr zuständiges Finanzamt.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_11 = new FonUidAbfrageServiceReturnCodes(104, false, "Die angefragte UID-Nummer kann im FinanzOnline nur in Stufe 1 bestätigt werden, da diese UID-Nummer zu einer Unternehmensgruppe (Umsatzsteuergruppe) gehört. Aus technischen Gründen werden aus der Slowakei keine Firmendaten angezeigt. Für eine gültige Stufe 2 Abfrage ist es daher erforderlich, dass Sie unter http://www.drsr.sk die Daten der SK-Umsatzsteuergruppe aufrufen und kontrollieren, ob das angefragte Unternehmen auch tatsächlich zu dieser Gruppe gehört. Bitte bewahren Sie den Ausdruck dieser Anfrage in Ihren Unterlagen als Beleg gemäß § 132 BAO auf. Für jede Anfrage Stufe 2 ist sowohl das Bestätigungsverfahren in Stufe 1 im FinanzOnline als auch das Gruppenregister im anderen Mitgliedsstaat laut o.a. Link zu konsultieren. Im Falle von Fragen wenden Sie sich bitte an Ihr zuständiges Finanzamt.");
        public static readonly FonUidAbfrageServiceReturnCodes RC_12 = new FonUidAbfrageServiceReturnCodes(105, false, "Die UID-Nummer ist über FinanzOnline einzeln abzufragen.");

        public static readonly FonUidAbfrageServiceReturnCodes RC_13 = new FonUidAbfrageServiceReturnCodes(1511, false, "Der angegebene Mitgliedstaat ist derzeit nicht erreichbar.");

        private FonUidAbfrageServiceReturnCodes(int returnCode, bool success, string errorMessage) : base(returnCode)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }

        public static FonUidAbfrageServiceReturnCodes GetByFonReturnCode(int fonReturnCode) => (FonUidAbfrageServiceReturnCodes)GetById(fonReturnCode);
    }
}