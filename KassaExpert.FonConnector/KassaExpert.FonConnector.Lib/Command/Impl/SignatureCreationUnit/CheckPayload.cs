namespace KassaExpert.FonConnector.Lib.Command.Impl.SignatureCreationUnit
{
    public sealed class CheckPayload
    {
        public CheckPayload(string hexSerial)
        {
            HexSerial = hexSerial; //TODO: check if real hex number or not
        }

        public string HexSerial { get; set; }
    }
}