using System;

namespace KassaExpert.FonConnector.Lib.Command
{
    public class CommandResult
    {
        public CommandResult(bool isSuccessful, string? errorMessage)
        {
            IsSuccessful = isSuccessful;

            if (!isSuccessful)
            {
                if (errorMessage is null)
                {
                    throw new ArgumentNullException(nameof(errorMessage), "a errormessage has to be set when a message was NOT successful");
                }

                ErrorMessage = errorMessage;
            }
        }

        public bool IsSuccessful { get; }

        public string? ErrorMessage { get; }
    }
}