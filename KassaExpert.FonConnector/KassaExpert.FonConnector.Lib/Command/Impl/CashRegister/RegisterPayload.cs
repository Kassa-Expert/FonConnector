namespace KassaExpert.FonConnector.Lib.Command.Impl.CashRegister
{
    public sealed class RegisterPayload
    {
        public RegisterPayload(string identificationNumber, string aesKeyBase64)
        {
            IdentificationNumber = identificationNumber;
            AesKeyBase64 = aesKeyBase64;
        }

        public string IdentificationNumber { get; set; }

        public string AesKeyBase64 { get; set; }
    }
}