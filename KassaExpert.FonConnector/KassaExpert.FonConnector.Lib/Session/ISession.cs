using KassaExpert.FonConnector.Lib.Command;
using System;

namespace KassaExpert.FonConnector.Lib.Session
{
    public interface ISession : IDisposable
    {
        ICommand<Command.Impl.SignatureCreationUnit.RegisterPayload, Command.Impl.SignatureCreationUnit.CheckPayload, Command.Impl.SignatureCreationUnit.DecommissioningPayload, Command.Impl.SignatureCreationUnit.RecommissioningPayload> SignatureCreationUnitCommand { get; }
    }
}