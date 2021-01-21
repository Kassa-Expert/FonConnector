namespace KassaExpert.FonConnector.Lib.Exception
{
    public class NoSessionException : System.Exception
    {
        public NoSessionException()
        { }

        public NoSessionException(string message) : base(message)
        { }
    }
}