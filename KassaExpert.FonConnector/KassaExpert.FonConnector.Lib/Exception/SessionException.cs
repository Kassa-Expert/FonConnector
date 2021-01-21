namespace KassaExpert.FonConnector.Lib.Exception
{
    public sealed class SessionException : NoSessionException
    {
        public SessionException()
        { }

        public SessionException(string message) : base(message)
        { }
    }
}