using Enum.Ext;

namespace KassaExpert.FonConnector.Lib.Enum
{
    public sealed class SignatureCreationUnitType : TypeSafeEnum<SignatureCreationUnitType, int>
    {
        public static readonly SignatureCreationUnitType SIGNATURKARTE = new SignatureCreationUnitType(1, "SIGNATURKARTE");
        public static readonly SignatureCreationUnitType EIGENES_HSM = new SignatureCreationUnitType(2, "EIGENES_HSM");
        public static readonly SignatureCreationUnitType HSM_DIENSTLEISTER = new SignatureCreationUnitType(3, "HSM_DIENSTLEISTER");

        private SignatureCreationUnitType(int id, string fonString) : base(id)
        {
            FonString = fonString;
        }

        public string FonString { get; }
    }
}