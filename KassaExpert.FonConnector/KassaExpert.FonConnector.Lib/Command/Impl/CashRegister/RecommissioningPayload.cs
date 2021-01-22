namespace KassaExpert.FonConnector.Lib.Command.Impl.CashRegister
{
    public sealed class RecommissioningPayload
    {
        public RecommissioningPayload(string identificationNumber)
        {
            IdentificationNumber = identificationNumber;
        }

        public string IdentificationNumber { get; set; }
    }
}