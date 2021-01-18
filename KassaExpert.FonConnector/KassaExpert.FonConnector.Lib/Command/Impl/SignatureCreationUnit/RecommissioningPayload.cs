namespace KassaExpert.FonConnector.Lib.Command.Impl.SignatureCreationUnit
{
    public sealed class RecommissioningPayload
    {
        public RecommissioningPayload(string hexSerial)
        {
            HexSerial = hexSerial; //TODO: check if real hex number or not
        }

        public string HexSerial { get; set; }
    }
}