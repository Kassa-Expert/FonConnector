using KassaExpert.FonConnector.Lib.Command;
using System;
using System.Threading.Tasks;
using KassaExpert.FonConnector.Lib.SessionService;
using KassaExpert.FonConnector.Lib.Enum;
using KassaExpert.FonConnector.Lib.Util;
using KassaExpert.FonConnector.Lib.Exception;
using KassaExpert.FonConnector.Lib.RegKassaService;

namespace KassaExpert.FonConnector.Lib.Session.Impl
{
    public sealed class FonSession : ISession
    {
        /// <summary>
        /// When _sessionId is null → currenly no valid Session open → throw error to client error instead of calling without Session
        /// </summary>
        private string? _sessionId;

        private bool _isTestSession = false;

        private readonly string _teilnehmerId;
        private readonly string _benutzerId;
        private readonly string _pin;

        public void SetTestSession(bool isTestSession)
        {
            _isTestSession = isTestSession;
        }

        /// <summary>
        /// used to prevent multiple events from happening at the same time
        /// </summary>
        private readonly TaskQueue _taskQueue = new TaskQueue();

        private bool _loginTried = false;

        internal Task<string> GetSessionId()
        {
            return _taskQueue.Enqueue(async () =>
            {
                if (!_loginTried)
                {
                    _loginTried = true;
                    await Login();
                }

                if (_sessionId is not null)
                {
                    return _sessionId;
                }

                throw new NoSessionException();
            });
        }

        public FonSession(string teilnehmerId, string benutzerId, string pin)
        {
            _teilnehmerId = teilnehmerId;
            _benutzerId = benutzerId;
            _pin = pin;

            SignatureCreationUnitCommand = new Command.Impl.SignatureCreationUnit.CommandImpl(this);
        }

        internal async Task<(CommandResult CommandResult, result Response)> ExecuteRkdbCommand(object command)
        {
            var request = new rkdbRequest1
            {
                rkdbRequest = new rkdbRequest
                {
                    tid = _teilnehmerId,
                    benid = _benutzerId,
                    id = await GetSessionId(),
                    art_uebermittlung = _isTestSession ? art_uebermittlung.T : art_uebermittlung.P,
                    erzwinge_asynchron = false,
                    Item = command
                }
            };

            var clt = new rkdbServicePortClient();

            await clt.OpenAsync();

            var response = await clt.rkdbAsync(request);

            await clt.CloseAsync();

            var status = FonRegKassaServiceReturnCodes.GetByFonReturnCode(response.rkdbResponse.result[0].rkdbMessage[0].rc);

            if (!status.Success)
            {
                return (new CommandResult(false, status.ErrorMessage), response.rkdbResponse.result[0]);
            }
            return (new CommandResult(false, status.ErrorMessage), response.rkdbResponse.result[0]);
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

            if (!status.Success)
            {
                throw new NoSessionException(status.ErrorMessage);
            }

            _sessionId = response.Body.id;
        }

        internal async Task Logout()
        {
            if (_sessionId is null)
                return;

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

            if (!status.Success)
            {
                throw new SessionException(status.ErrorMessage);
            }

            _sessionId = null;
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
                Task.Run(async () => await Logout()).Wait();
            }

            _disposed = true;
        }

        #endregion IDisposable
    }
}