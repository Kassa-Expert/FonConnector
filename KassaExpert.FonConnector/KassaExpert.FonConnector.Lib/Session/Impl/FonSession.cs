using KassaExpert.FonConnector.Lib.Command;
using System;
using System.Collections.Generic;
using System.Text;
using KassaExpert.FonConnector.Lib.Command.Impl;
using System.Threading.Tasks;
using KassaExpert.FonConnector.Lib.SessionService;
using KassaExpert.FonConnector.Lib.Enum;

namespace KassaExpert.FonConnector.Lib.Session.Impl
{
    public sealed class FonSession : ISession
    {
        /// <summary>
        /// When _sessionId is null → currenly no valid Session open → throw error to client error instead of calling without Session
        /// </summary>
        private string? _sessionId;

        private readonly string _teilnehmerId;
        private readonly string _benutzerId;
        private readonly string _pin;

        internal bool HasSession => _sessionId is not null;

        internal string? GetSessionId() => _sessionId;

        public FonSession(string teilnehmerId, string benutzerId, string pin)
        {
            _teilnehmerId = teilnehmerId;
            _benutzerId = benutzerId;
            _pin = pin;

            SignatureCreationUnitCommand = new Command.Impl.SignatureCreationUnit.CommandImpl(this);
        }

        internal async Task Login()
        {
            var clt = new sessionServicePortClient();

            await clt.OpenAsync();

            var response = await clt.loginAsync(new loginRequest
            {
                Body = new loginRequestBody
                {
                    benid = _benutzerId,
                    herstellerid = Environment.GetEnvironmentVariable("HERSTELLER_UID", EnvironmentVariableTarget.User),
                    pin = _pin,
                    tid = _teilnehmerId
                }
            });

            await clt.CloseAsync();

            var status = FonSessionServiceReturnCodes.GetByFonReturnCode(response.Body.rc);

            if (status != FonSessionServiceReturnCodes.RC_00)
            {
                throw new Exception(status.ErrorMessage);
            }

            _sessionId = response.Body.id;
        }

        internal async Task Logout()
        {
            var clt = new sessionServicePortClient();

            await clt.OpenAsync();

            var response = await clt.logoutAsync(new logoutRequest
            {
                Body = new logoutRequestBody
                {
                    tid = _teilnehmerId,
                    benid = _benutzerId,
                    id = _sessionId
                }
            });

            await clt.CloseAsync();

            var status = FonSessionServiceReturnCodes.GetByFonReturnCode(response.Body.rc);

            if (status != FonSessionServiceReturnCodes.RC_00)
            {
                throw new Exception(status.ErrorMessage);
            }
        }

        public ICommand<Command.Impl.SignatureCreationUnit.RegisterPayload, Command.Impl.SignatureCreationUnit.CheckPayload, Command.Impl.SignatureCreationUnit.DecommissioningPayload, Command.Impl.SignatureCreationUnit.RecommissioningPayload> SignatureCreationUnitCommand { get; }

        #region IDisposable

        private bool _disposed = false;

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }

        #endregion IDisposable
    }
}