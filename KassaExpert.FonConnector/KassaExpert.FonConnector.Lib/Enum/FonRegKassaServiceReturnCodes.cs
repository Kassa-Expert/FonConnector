using Enum.Ext;
using System.Linq;

namespace KassaExpert.FonConnector.Lib.Enum
{
    /// <summary>
    /// to check the response code given here: https://www.bmf.gv.at/dam/jcr:19c193f4-99cd-42ff-9b23-655f2ab5734e/BMF_Registrierkassen_Webservice.pdf
    /// </summary>
    public sealed class FonRegKassaServiceReturnCodes : TypeSafeEnum<FonRegKassaServiceReturnCodes, int>
    {
        public static readonly FonRegKassaServiceReturnCodes RC_00 = new FonRegKassaServiceReturnCodes(00, true, "0", "Aufruf ok");
        public static readonly FonRegKassaServiceReturnCodes RC_01 = new FonRegKassaServiceReturnCodes(01, false, "-1", "Die Session ID ist ungültig oder abgelaufen.");
        public static readonly FonRegKassaServiceReturnCodes RC_02 = new FonRegKassaServiceReturnCodes(02, false, "-2", "Der Aufruf des Webservices ist derzeit wegen Wartungsarbeiten nicht möglich.");
        public static readonly FonRegKassaServiceReturnCodes RC_03 = new FonRegKassaServiceReturnCodes(03, false, "-3", "Es ist ein technischer Fehler aufgetreten.");
        public static readonly FonRegKassaServiceReturnCodes RC_04 = new FonRegKassaServiceReturnCodes(04, false, "-4", "Dieser Teilnehmer ist für diese Funktion nicht berechtigt."); //CHECK FOR USER PRIVILEGES

        public static readonly FonRegKassaServiceReturnCodes RC_05 = new FonRegKassaServiceReturnCodes(05, false, "4", "Mit der angegebenen Seriennummer konnte beim angegebenen Vertrauensdiensteanbieter kein Zertifikat gefunden werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_06 = new FonRegKassaServiceReturnCodes(06, false, "5", "Der Status des Zertifikates ist nicht gültig. Wenden Sie sich bitte an Ihren Vertrauensdiensteanbieter.");
        public static readonly FonRegKassaServiceReturnCodes RC_07 = new FonRegKassaServiceReturnCodes(07, false, "6", "Die OID des Zertifikates für \"Österreichische Finanzverwaltung Registrierkasseninhaber\" ist nicht vorhanden.");
        public static readonly FonRegKassaServiceReturnCodes RC_08 = new FonRegKassaServiceReturnCodes(08, false, "7", "Der Ordnungsbegriff im Zertifikat ist nicht dem registrierenden Unternehmen zugeordnet.Wenden Sie sich bitte an Ihren Vertrauensdiensteanbieter.");
        public static readonly FonRegKassaServiceReturnCodes RC_09 = new FonRegKassaServiceReturnCodes(09, false, "8", "Der Wert in der OID für \"Österreichische Finanzverwaltung Registrierkasseninhaber\" ist ungültig.Bei Fragen wenden Sie sich bitte an Ihren Vertrauensdiensteanbieter.");
        public static readonly FonRegKassaServiceReturnCodes RC_10 = new FonRegKassaServiceReturnCodes(10, false, "9", "Das Zertifikat ist fehlerhaft. Wenden Sie sich bitte an Ihren Vertrauensdiensteanbieter.");
        public static readonly FonRegKassaServiceReturnCodes RC_11 = new FonRegKassaServiceReturnCodes(11, false, "13", "Die Registrierung einer Signaturerstellungseinheit ist nicht möglich, da weder Steuernummer, UID - Nummer noch GLN(Global Location Number) in der Finanzverwaltung vorhanden sind.Bei Fragen wenden Sie sich bitte an Ihr zuständiges Finanzamt.");
        public static readonly FonRegKassaServiceReturnCodes RC_12 = new FonRegKassaServiceReturnCodes(12, false, "14", "Der Zugriff auf die Zertifikate Ihres Vertrauensdiensteanbieters ist aktuell nicht möglich. Versuchen Sie es bitte zu einem späteren Zeitpunkt erneut.");
        public static readonly FonRegKassaServiceReturnCodes RC_13 = new FonRegKassaServiceReturnCodes(13, false, "27", "Der angegebene Ordnungsbegriff ist ungültig.");
        public static readonly FonRegKassaServiceReturnCodes RC_14 = new FonRegKassaServiceReturnCodes(14, false, "28", "Der angegebene Ordnungsbegriff ist nicht dem registrierenden Unternehmen zugeordnet.");
        public static readonly FonRegKassaServiceReturnCodes RC_15 = new FonRegKassaServiceReturnCodes(15, false, "29", "Der öffentliche Schlüssel ist ungültig.");
        public static readonly FonRegKassaServiceReturnCodes RC_16 = new FonRegKassaServiceReturnCodes(16, false, "30", "Der öffentliche Schlüssel entspricht nicht dem veröffentlichten Format.");
        public static readonly FonRegKassaServiceReturnCodes RC_17 = new FonRegKassaServiceReturnCodes(17, false, "31", "Die Überprüfung des Zertifikates ist fehlgeschlagen. Bei Fragen wenden Sie sich bitte an Ihren Vertrauensdiensteanbieter.");
        public static readonly FonRegKassaServiceReturnCodes RC_18 = new FonRegKassaServiceReturnCodes(18, false, "32", "Es ist keine steuerliche Vertretungsvollmacht vorhanden.");
        public static readonly FonRegKassaServiceReturnCodes RC_19 = new FonRegKassaServiceReturnCodes(19, false, "36", "Die angegebene ID des Vertrauensdiensteanbieters (vda_id) ist nicht zulässig.");
        public static readonly FonRegKassaServiceReturnCodes RC_20 = new FonRegKassaServiceReturnCodes(20, false, "41", "Das Zertifikat ist noch nicht bzw. nicht mehr gültig. Wenden Sie sich bitte an Ihren Vertrauensdiensteanbieter.");
        public static readonly FonRegKassaServiceReturnCodes RC_21 = new FonRegKassaServiceReturnCodes(21, false, "43", "Der übermittelte Beleg ist fehlerhaft.");

        public static readonly FonRegKassaServiceReturnCodes RC_22 = new FonRegKassaServiceReturnCodes(22, false, "998", "Eine Statusabfrage für Signaturerstellungseinheit, Registrierkasse und geschlossenes Gesamtsystem ist bei asynchroner Verarbeitung nicht zulässig.");
        public static readonly FonRegKassaServiceReturnCodes RC_23 = new FonRegKassaServiceReturnCodes(23, false, "999", "Die VDA-Id \"AT9\" ist nur bei Testübermittlungen zulässig.");

        public static readonly FonRegKassaServiceReturnCodes RC_24 = new FonRegKassaServiceReturnCodes(24, false, "1336", "(1336) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_25 = new FonRegKassaServiceReturnCodes(25, false, "1337", "(1337) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");

        public static readonly FonRegKassaServiceReturnCodes RC_26 = new FonRegKassaServiceReturnCodes(26, false, "B1", "Die Registrierkasse mit der angegebenen Kassenidentifikationsnummer ist bereits registriert.");
        public static readonly FonRegKassaServiceReturnCodes RC_27 = new FonRegKassaServiceReturnCodes(27, false, "B2", "Für Kassen im vorliegenden Status ist keine Änderung der Daten möglich.");
        public static readonly FonRegKassaServiceReturnCodes RC_28 = new FonRegKassaServiceReturnCodes(28, false, "B3", "Für das Unternehmen konnte kein Ordnungsbegriff (Steuernummer, Global Location Number, UID - Nummer) ermittelt werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_29 = new FonRegKassaServiceReturnCodes(29, false, "B4", "(B4) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_30 = new FonRegKassaServiceReturnCodes(30, false, "B5", "Der angegebene Zeitpunkt darf nicht vor dem Zeitpunkt der letzten Statusänderung liegen.");
        public static readonly FonRegKassaServiceReturnCodes RC_31 = new FonRegKassaServiceReturnCodes(31, false, "B6", "Es erfolgte bereits eine Außerbetriebnahme. Eine Änderung ist nicht mehr möglich.");
        public static readonly FonRegKassaServiceReturnCodes RC_32 = new FonRegKassaServiceReturnCodes(32, false, "B7", "Es ist keine in Betrieb befindliche Signaturerstellungseinheit vorhanden.");
        public static readonly FonRegKassaServiceReturnCodes RC_33 = new FonRegKassaServiceReturnCodes(33, false, "B8", "Nur in Betrieb befindliche, registrierte oder ausgefallene Registrierkassen dürfen außer Betrieb genommen werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_34 = new FonRegKassaServiceReturnCodes(34, false, "B9", "Nur in Betrieb befindliche Registrierkassen dürfen als ausgefallen gemeldet werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_35 = new FonRegKassaServiceReturnCodes(35, false, "B10", "Die angegebene Signaturerstellungseinheit ist mit dem angegebenen Vertrauensdiensteanbieter und der Seriennummer des Zertifikates bereits in der Datenbank gespeichert.");
        public static readonly FonRegKassaServiceReturnCodes RC_36 = new FonRegKassaServiceReturnCodes(36, false, "B13", "Der angegebene Status ist bereits gesetzt.");
        public static readonly FonRegKassaServiceReturnCodes RC_37 = new FonRegKassaServiceReturnCodes(37, false, "B14", "Es wurde keine Begründung angegeben.");
        public static readonly FonRegKassaServiceReturnCodes RC_38 = new FonRegKassaServiceReturnCodes(38, false, "B15", "Der Zeitpunkt des Ausfalles darf nicht leer sein.");
        public static readonly FonRegKassaServiceReturnCodes RC_39 = new FonRegKassaServiceReturnCodes(39, false, "B18", "Nur in Betrieb befindliche oder ausgefallene Signaturerstellungseinheiten dürfen endgültig außer Betrieb genommen werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_40 = new FonRegKassaServiceReturnCodes(40, false, "B19", "Nur in Betrieb befindliche Signaturerstellungseinheiten dürfen als ausgefallen gemeldet werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_41 = new FonRegKassaServiceReturnCodes(41, false, "B20", "Die Begründung ist nicht (mehr) gültig.");
        public static readonly FonRegKassaServiceReturnCodes RC_42 = new FonRegKassaServiceReturnCodes(42, false, "B21", "Der angegebene Zeitpunkt darf nicht in der Zukunft liegen.");
        public static readonly FonRegKassaServiceReturnCodes RC_43 = new FonRegKassaServiceReturnCodes(43, false, "B22", "Dieser Status ist nicht verfügbar.");
        public static readonly FonRegKassaServiceReturnCodes RC_44 = new FonRegKassaServiceReturnCodes(44, false, "B28", "Der öffentliche Schlüssel ist bereits vorhanden.");
        public static readonly FonRegKassaServiceReturnCodes RC_45 = new FonRegKassaServiceReturnCodes(45, false, "B29", "Es muss ein Zusatz zum Ordnungsbegriff angegeben werden.");
        public static readonly FonRegKassaServiceReturnCodes RC_46 = new FonRegKassaServiceReturnCodes(46, false, "B30", "Dieser Zusatz zum Ordnungsbegriff ist bereits vorhanden.");
        public static readonly FonRegKassaServiceReturnCodes RC_47 = new FonRegKassaServiceReturnCodes(47, false, "B32", "Die Kassenidentifikationsnummer ist nicht registriert oder bereits außer Betrieb genommen.");
        public static readonly FonRegKassaServiceReturnCodes RC_48 = new FonRegKassaServiceReturnCodes(48, false, "B33", "Die Seriennummer ist nicht registriert oder bereits außer Betrieb genommen.");
        public static readonly FonRegKassaServiceReturnCodes RC_49 = new FonRegKassaServiceReturnCodes(49, false, "B34", "Der Ordnungsbegriff ist nicht registriert oder bereits außer Betrieb genommen.");
        public static readonly FonRegKassaServiceReturnCodes RC_50 = new FonRegKassaServiceReturnCodes(50, false, "B35", "Der Begründungscode ist nicht vorhanden.");

        public static readonly FonRegKassaServiceReturnCodes RC_51 = new FonRegKassaServiceReturnCodes(51, false, "C1", "(C1) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");

        public static readonly FonRegKassaServiceReturnCodes RC_52 = new FonRegKassaServiceReturnCodes(52, false, "V1", "(V1) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_53 = new FonRegKassaServiceReturnCodes(53, false, "V2", "(V2) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_54 = new FonRegKassaServiceReturnCodes(54, false, "V3", "(V3) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_55 = new FonRegKassaServiceReturnCodes(55, false, "V4", "(V4) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_56 = new FonRegKassaServiceReturnCodes(56, false, "V5", "(V5) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_57 = new FonRegKassaServiceReturnCodes(57, false, "V6", "(V6) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_58 = new FonRegKassaServiceReturnCodes(58, false, "V7", "(V7) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_59 = new FonRegKassaServiceReturnCodes(59, false, "V8", "(V8) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_60 = new FonRegKassaServiceReturnCodes(60, false, "V9", "(V9) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_61 = new FonRegKassaServiceReturnCodes(61, false, "V10", "(V10) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_62 = new FonRegKassaServiceReturnCodes(62, false, "V11", "(V11) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_63 = new FonRegKassaServiceReturnCodes(63, false, "V12", "(V12) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_64 = new FonRegKassaServiceReturnCodes(64, false, "V13", "(V13) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_65 = new FonRegKassaServiceReturnCodes(65, false, "V14", "(V14) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_66 = new FonRegKassaServiceReturnCodes(66, false, "V15", "(V15) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");
        public static readonly FonRegKassaServiceReturnCodes RC_67 = new FonRegKassaServiceReturnCodes(67, false, "V16", "(V16) Ein interner Fehler ist aufgetreten. Bitte versuchen Sie es zu einem späteren Zeitpunkt nochmal oder wenden Sie sich an die Hotline(050 233 790, MO - FR 08:00 - 17:00).");

        private FonRegKassaServiceReturnCodes(int id, bool success, string returnCode, string errorMessage) : base(id)
        {
            Success = success;
            ReturnCode = returnCode;
            ErrorMessage = errorMessage;
        }

        public string ReturnCode { get; }

        public bool Success { get; }

        public string ErrorMessage { get; }

        public static FonRegKassaServiceReturnCodes GetByFonReturnCode(string fonReturnCode) => List.Single(e => e.ReturnCode == fonReturnCode);
    }
}