using KassaExpert.FonConnector.Lib.Command;
using System;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.Lib.Session
{
    public interface ISession : IDisposable
    {
        void SetTestSession(bool isTestSession);

        ICommand<Command.Impl.SignatureCreationUnit.RegisterPayload, Command.Impl.SignatureCreationUnit.CheckPayload, Command.Impl.SignatureCreationUnit.DecommissioningPayload, Command.Impl.SignatureCreationUnit.RecommissioningPayload> SignatureCreationUnitCommand { get; }

        ICommand<Command.Impl.CashRegister.RegisterPayload, Command.Impl.CashRegister.CheckPayload, Command.Impl.CashRegister.DecommissioningPayload, Command.Impl.CashRegister.RecommissioningPayload> CashRegisterCommand { get; }

        Task<CommandResult> CheckSignature(string maschinenlesbarerCode);

        /// <summary>
        /// When IsSuccessful true → got answer from FON-Server
        /// When Payload true → UID is valid
        /// </summary>
        Task<CommandResult> CheckUid(string uid);
    }
}