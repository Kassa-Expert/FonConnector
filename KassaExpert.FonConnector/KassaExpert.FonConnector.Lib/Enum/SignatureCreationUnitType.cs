using Enum.Ext;
using KassaExpert.FonConnector.Lib.RegKassaService;

namespace KassaExpert.FonConnector.Lib.Enum
{
    public sealed class SignatureCreationUnitType : TypeSafeEnum<SignatureCreationUnitType, int>
    {
        public static readonly SignatureCreationUnitType SIGNATURKARTE = new SignatureCreationUnitType(1, "SIGNATURKARTE", art_se.SIGNATURKARTE);
        public static readonly SignatureCreationUnitType EIGENES_HSM = new SignatureCreationUnitType(2, "EIGENES_HSM", art_se.EIGENES_HSM);
        public static readonly SignatureCreationUnitType HSM_DIENSTLEISTER = new SignatureCreationUnitType(3, "HSM_DIENSTLEISTER", art_se.HSM_DIENSTLEISTER);

        private SignatureCreationUnitType(int id, string fonString, art_se fonType) : base(id)
        {
            FonString = fonString;
            FonType = fonType;
        }

        public string FonString { get; }

        public art_se FonType { get; }
    }
}