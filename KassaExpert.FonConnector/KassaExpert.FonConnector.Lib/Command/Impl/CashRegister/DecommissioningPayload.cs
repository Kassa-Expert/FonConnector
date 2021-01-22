using KassaExpert.FonConnector.Lib.Enum;

namespace KassaExpert.FonConnector.Lib.Command.Impl.CashRegister
{
    public sealed class DecommissioningPayload
    {
        public DecommissioningPayload(SignatureCreationUnitDecommissioningType type, string identificationNumber)
        {
            Type = type;
            IdentificationNumber = identificationNumber;
        }

        public SignatureCreationUnitDecommissioningType Type { get; set; }

        public string IdentificationNumber { get; set; }
    }
}