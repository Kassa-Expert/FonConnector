using KassaExpert.FonConnector.Lib.Enum;
using KassaExpert.Util.Lib.Enum;

namespace KassaExpert.FonConnector.Lib.Command.Impl.SignatureCreationUnit
{
    public sealed class RegisterPayload
    {
        public RegisterPayload(SignatureCreationUnitType type, TrustProvider provider, string hexSerial)
        {
            Type = type;
            Provider = provider;
            HexSerial = hexSerial; //TODO: check if real hex number or not
        }

        public SignatureCreationUnitType Type { get; set; }

        public TrustProvider Provider { get; set; }

        public string HexSerial { get; set; }
    }
}