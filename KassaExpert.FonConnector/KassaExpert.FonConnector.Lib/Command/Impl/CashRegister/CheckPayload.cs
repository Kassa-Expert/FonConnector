namespace KassaExpert.FonConnector.Lib.Command.Impl.CashRegister
{
    public sealed class CheckPayload
    {
        public CheckPayload(string identificationNumber)
        {
            IdentificationNumber = identificationNumber;
        }

        public string IdentificationNumber { get; set; }
    }
}