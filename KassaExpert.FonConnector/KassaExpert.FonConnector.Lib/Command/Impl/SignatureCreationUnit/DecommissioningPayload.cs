using KassaExpert.FonConnector.Lib.Enum;

namespace KassaExpert.FonConnector.Lib.Command.Impl.SignatureCreationUnit
{
    public sealed class DecommissioningPayload
    {
        public DecommissioningPayload(SignatureCreationUnitDecommissioningType type, string hexSerial)
        {
            Type = type;
            HexSerial = hexSerial; //TODO: check if real hex number or not
        }

        public SignatureCreationUnitDecommissioningType Type { get; set; }

        public string HexSerial { get; set; }
    }
}