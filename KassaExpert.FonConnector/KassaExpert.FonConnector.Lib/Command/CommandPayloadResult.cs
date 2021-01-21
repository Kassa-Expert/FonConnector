using System;

namespace KassaExpert.FonConnector.Lib.Command
{
    public sealed class CommandPayloadResult<T> : CommandResult
        where T : struct
    {
        public CommandPayloadResult(bool isSuccessful, T? payload, string? errorMessage) : base(isSuccessful, errorMessage)
        {
            if (isSuccessful)
            {
                if (payload is null)
                {
                    throw new ArgumentNullException(nameof(payload), "a payload has to be set when a message was successful");
                }

                Payload = payload;
            }
        }

        public CommandPayloadResult(CommandResult commandResult, T? payload) : this(commandResult.IsSuccessful, payload, commandResult.ErrorMessage)
        {
        }

        public T? Payload { get; }
    }
}